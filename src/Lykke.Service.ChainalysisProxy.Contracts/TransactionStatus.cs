<<<<<<< HEAD
﻿using System;
namespace Lykke.Service.ChainalysisProxy.Contracts
=======
﻿namespace Lykke.Service.ChainalysisProxy.Contracts
>>>>>>> feature/LWDEV-8491_Add-new-method-to-provide-information-about-chainalysis-response
{
    public class TransactionStatus
    {
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
