using Lykke.Service.ChainalysisProxy.Core.Domain;

namespace Lykke.Service.ChainalysisProxy.Services
{
    public class TransactionStatus : ITransactionStatus
    {
        public TransactionStatus(){
            
        }

        public TransactionStatus(ITransactionStatus transactionStatus)
        {
            ClientId = transactionStatus.ClientId;
            TransactionHash = transactionStatus.TransactionHash;
            OutputNumber = transactionStatus.OutputNumber;
            TransactionAmount = transactionStatus.TransactionAmount;
            ChainalysisName = transactionStatus.ChainalysisName;
            ChainalysisRiskScore = transactionStatus.ChainalysisRiskScore;
            ChainalysisCategory = transactionStatus.ChainalysisCategory;
            WalletAddress = transactionStatus.WalletAddress;
        }

        public string ClientId { get; set; }
        public string TransactionHash { get; set; }
        public int OutputNumber { get; set; }
        public decimal TransactionAmount { get; set; }
        public string ChainalysisName { get; set; }
        public RiskScore ChainalysisRiskScore { get; set; }
        public string ChainalysisCategory { get; set; }
        public string WalletAddress { get; set; }
    }
}