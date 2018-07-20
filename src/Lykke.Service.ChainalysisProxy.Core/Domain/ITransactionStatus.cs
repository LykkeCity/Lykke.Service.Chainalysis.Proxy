using System;
namespace Lykke.Service.ChainalysisProxy.Core.Domain
{
    public interface ITransactionStatus
    {
        string ClientId { get; set; }
        string TransactionHash { get; set; }
        int OutputNumber { get; set; }
        decimal TransactionAmount { get; set; }
        string ChainalysisName { get; set; }
        RiskScore ChainalysisRiskScore { get; set; }
        string ChainalysisCategory { get; set; }
        string WalletAddress { get; set; }
    }
}
