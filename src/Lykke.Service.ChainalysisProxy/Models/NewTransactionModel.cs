
using Lykke.Service.ChainalysisProxy.Core.Domain;

namespace Lykke.Service.ChainalysisProxy.Models
{
    public class NewTransactionModel : INewTransactionModel
    {
        public string Transaction { get; set; }
        public string Output { get; set; }
        public TransactionType TransactionType { get; set; }
        public string outName { get; set; }
        public string outScore { get; set; }
        public string outCategory { get; set; }
    }
}
