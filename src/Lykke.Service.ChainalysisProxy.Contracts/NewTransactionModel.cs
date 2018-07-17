using System;

namespace Lykke.Service.ChainalysisProxy.Contracts
{
    public class NewTransactionModel
    {
        public string Transaction { get; set; }
        public string Output { get; set; }
        public TransactionType TransactionType { get; set; }
        public string OutName { get; set; }
        public Contracts.RiskScore? OutScore { get; set; }
        public string OutCategory { get; set; }
    }
}
