using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Service.ChainalysisProxy.Core.Domain;

namespace Lykke.Service.ChainalysisProxy.Models
{
    public class NewWalletModel : INewWalletModel
    {
        public string Address { get; set; }
        public WalletType WalletType { get; set; }
    }
}
