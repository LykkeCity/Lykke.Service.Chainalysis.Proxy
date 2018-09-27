﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ChainalysisProxy.Contracts
{
    public class UserScoreDetails
    {
        public Guid UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Comment { get; set; }
        public DateTime LastActivity { get; set; }
        public RiskScore? Score { get; set; }
        public DateTime ScoreUpdatedDate { get; set; }
        public List<ExposureDetails> ExposureDetails { get; set; }
    }
}
