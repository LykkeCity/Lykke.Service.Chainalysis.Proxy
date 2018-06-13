using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Service.ChainalysisProxy.Core.Domain;

namespace Lykke.Service.ChainalysisProxy.Models
{
    public class NewTransactionModel : INewTransactionModel
    {
        public string Transaction { get; set; }
        public string Output { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
