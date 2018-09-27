namespace Lykke.Service.ChainalysisProxy.Contracts
{
    public class TransactionStatus
    {
        public string ClientId { get; set; }
        public string TransactionHash { get; set; }
        public int OutputNumber { get; set; }
        public decimal TransactionAmount { get; set; }
        public string ChainalysisName { get; set; }
        public string ChainalysisRiskScore { get; set; }
        public string ChainalysisCategory { get; set; }
        public string WalletAddress { get; set; }
    }
}
