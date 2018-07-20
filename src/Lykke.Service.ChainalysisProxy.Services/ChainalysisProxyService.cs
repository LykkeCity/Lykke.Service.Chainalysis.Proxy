using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lykke.Service.ChainalysisMock.Client;
using Lykke.Service.ChainalysisMock.Client.AutorestClient;
using Lykke.Service.ChainalysisProxy.Core.Domain;
using Lykke.Service.ChainalysisProxy.Core.Repositories;
using Lykke.Service.ChainalysisProxy.Core.Services;
using AddressImportModel = Lykke.Service.ChainalysisMock.Client.AutorestClient.Models.AddressImportModel;
using OutputImportModel = Lykke.Service.ChainalysisMock.Client.AutorestClient.Models.OutputImportModel;
using UserImportModel = Lykke.Service.ChainalysisMock.Client.AutorestClient.Models.UserImportModel;

namespace Lykke.Service.ChainalysisProxy.Services
{
    public class ChainalysisProxyService : IChainalysisProxyService
    {
        private readonly IChainalysisProxyUserRepository _userRepository;
        private readonly IChainalysisTransactionStatusRepository _transactionRepository;
        private readonly IChainalysisMockClient _riskApi;
        private readonly string _chainalisisKey;

        public ChainalysisProxyService(
            IChainalysisProxyUserRepository userRepository,
            IChainalysisTransactionStatusRepository transactionRepository,
            IChainalysisMockClient riskApi,
            Core.Settings.ServiceSettings.Services services)
        {
            _userRepository = userRepository;
            _riskApi = riskApi;
            _chainalisisKey = services.CainalisysKey;
            _transactionRepository = transactionRepository;
        }

        public async Task<IUserScoreDetails> RegisterUser(string userId)
        {
            var user = await _userRepository.GetUser(userId);
            await _riskApi.ImportUserAsync(new UserImportModel(user), _chainalisisKey);
            return await GetUserScopeDetails(user, userId);
        }

        public async Task<IUserScoreDetails> GetUserScore(string userId)
        {
            var user = await _userRepository.GetUser(userId, false);
            if(user == null)
            {
                return null;
            }
            return await GetUserScopeDetails(user, userId);
        }

        public async Task AddTransaction(string userId, INewTransactionModel transaction)
        {
            var user = await _userRepository.GetUser(userId);
            if (transaction.TransactionType == TransactionType.Reseived)
            {
                var r = await _riskApi.AddOutputsReceivedAsync(user, new OutputImportModel($"{transaction.Transaction}:{transaction.Output}"), _chainalisisKey);
                transaction.outName = r.Name;
                transaction.outScore = r.Score;
                transaction.outCategory = r.Category;
            }
            else
            {
                await _riskApi.AddOutputsSentAsync(user, new OutputImportModel($"{transaction.Transaction}:{transaction.Output}"), _chainalisisKey);
            }

        }

        public async Task<IUserScoreDetails> AddWallet(string userId, INewWalletModel wallet)
        {
            var user = await _userRepository.GetUser(userId);
            if (wallet.WalletType == WalletType.Deposit)
            {
                await _riskApi.AddAddressesDepositAsync(user, new AddressImportModel(wallet.Address), _chainalisisKey);
            }
            else
            {
                await _riskApi.AddAddressesWithdrawalAsync(user, new AddressImportModel(wallet.Address), _chainalisisKey);
            }
            return await GetUserScopeDetails(user, userId);
        }

        /// <summary>
        /// userId is Chainalysis!!!
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private async Task<IUserScoreDetails> GetUserScopeDetails(string userId, string origUserId)
        {
            var result = await _riskApi.GetUserAsync(userId, _chainalisisKey);
            return new UserScoreDetails(result, origUserId);
        }

        public async Task<string> GetChainalysisId(string userId)
        {
            return await _userRepository.GetUser(userId, false);
        }

        public async Task<IReadOnlyList<ITransactionStatus>> GetTransactionsByClientIdAndWalletAsync(string clientId, string wallet)
        {
            var result = await _transactionRepository.GetTransactionsByClientIdAsync(wallet);
            return result.Where(tr => tr.ClientId.Equals(clientId)).Select(tr=>new TransactionStatus(tr)).ToList();
        }
    }
}
