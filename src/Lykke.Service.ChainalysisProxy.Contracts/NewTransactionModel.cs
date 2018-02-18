using System;

namespace Lykke.Service.ChainalysisProxy.Contracts
{
    public class NewTransactionModel
    {
        public string Transaction { get; set; }
        public int Output { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
