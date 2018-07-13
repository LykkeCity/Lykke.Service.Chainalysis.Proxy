

using System.Threading.Tasks;
using Lykke.Service.ChainalysisProxy.Core.Domain;

namespace Lykke.Service.ChainalysisProxy.Core.Services
{
    public interface IChainalysisProxyService
    {


        Task<IUserScoreDetails> RegisterUser(string userId);

        Task<IUserScoreDetails> GetUserScore(string userId);

        Task AddTransaction(string userId, INewTransactionModel transaction);

        Task<IUserScoreDetails> AddWallet(string userId, INewWalletModel wallet);

        Task<string> GetChainalysisId(string userId);
    }
}
