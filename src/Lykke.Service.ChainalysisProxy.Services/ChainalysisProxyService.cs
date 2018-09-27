using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lykke.Service.ChainalysisMock.Client;
using Lykke.Service.ChainalysisProxy.AzureRepositories;
using Lykke.Service.ChainalysisProxy.Contracts;

namespace Lykke.Service.ChainalysisProxy.Services
{
    public class ChainalysisProxyService : IChainalysisProxyService
    {
        private readonly IChainalysisTransactionStatusRepository _transactionRepository;
        private readonly IChainalysisMockClient _riskApi;
        private readonly string _chainalysisKey;

        public ChainalysisProxyService(
            IChainalysisTransactionStatusRepository transactionRepository,
            IChainalysisMockClient riskApi,
            string chainalysisKey
            )
        {
            _riskApi = riskApi;
            _chainalysisKey = chainalysisKey;
            _transactionRepository = transactionRepository;
        }
        
        public async Task<UserScoreDetails> GetUserScore(Guid userId)
        {
            var result = await _riskApi.GetUserAsync(userId.ToString(), _chainalysisKey);

            var details = new UserScoreDetails
            {
                CreationDate = result.CreationDate.ToDateTime(),
                Comment = result.Comment,
                LastActivity = result.LastActivity.ToDateTime(),
                ExposureDetails = new List<ExposureDetails>(),
                UserId = userId
            };


            if (result.ExposureDetails != null)
            {
                details.ExposureDetails.AddRange(from ed in result.ExposureDetails
                    select new ExposureDetails
                    {
                        Category = ed.Category,
                        SentDirectExposure = ed.SentDirectExposure,
                        SentIndirectExposure = ed.SentIndirectExposure,
                        ReceivedDirectExposure = ed.ReceivedDirectExposure,
                        ReceivedIndirectExposure = ed.ReceivedIndirectExposure
                    });
            }

            if (!Enum.TryParse(result.Score, true, out RiskScore riskScore))
            {
                details.Score = null;
            }
            else
            {
                details.Score = riskScore;
            }
            details.ScoreUpdatedDate = result.ScoreUpdatedDate.ToDateTime();

            return details;
        }
        
        public async Task<IEnumerable<TransactionStatus>> GetTransactionsByClientIdAndWalletAsync(Guid clientId, Guid wallet)
        {
            var result = await _transactionRepository.GetTransactionsByClientIdAsync(wallet);
            return result.Where(tr => tr.ClientId.Equals(clientId.ToString())).Select(transactionStatus => new TransactionStatus
            {
                ClientId = transactionStatus.ClientId,
                TransactionHash = transactionStatus.TransactionHash,
                OutputNumber = transactionStatus.OutputNumber,
                TransactionAmount = transactionStatus.TransactionAmount,
                ChainalysisName = transactionStatus.ChainalysisName,
                ChainalysisRiskScore = transactionStatus.ChainalysisScore,
                ChainalysisCategory = transactionStatus.ChainalysisCategory,
                WalletAddress = transactionStatus.WalletAddress
        }).ToList();
        }
    }
}
