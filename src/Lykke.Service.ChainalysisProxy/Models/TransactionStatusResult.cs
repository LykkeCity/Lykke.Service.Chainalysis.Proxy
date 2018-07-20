using System.Collections.Generic;
using Lykke.Service.ChainalysisProxy.Core.Domain;

namespace Lykke.Service.ChainalysisProxy.Models
{
    public class TransactionStatusResult
    {
        public IReadOnlyList<ITransactionStatus> Transactions { get; set; }
    }
}
