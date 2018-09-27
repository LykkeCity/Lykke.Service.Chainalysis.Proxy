using System.Collections.Generic;

namespace Lykke.Service.ChainalysisProxy.Contracts
{
    public class TransactionStatusResult
    {
        public IEnumerable<TransactionStatus> Transactions { get; set; }
    }
}
