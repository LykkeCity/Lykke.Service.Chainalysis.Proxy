using System;
using System.Collections.Generic;
using System.Linq;
using Lykke.Service.Chainalysis.Mock.Contracts;
using Lykke.Service.ChainalysisProxy.Core.Domain;
using RiskScore = Lykke.Service.ChainalysisProxy.Core.Domain.RiskScore;

namespace Lykke.Service.ChainalysisProxy.Services
{
    internal class UserScoreDetails : IUserScoreDetails
    {
        public UserScoreDetails(UserDetailsModel result)
        {
            CreationDate = result.CreationDate.ToDateTime();
            Comment = result.Comment;
            LastActivity = result.LastActivity == 0 ? null : (DateTime?)result.LastActivity.ToDateTime();
            RiskScore riskScore;
            if(!Enum.TryParse(result.Score, out riskScore))
            {
                Score = null;
            }
            else
            {
                Score = riskScore;
            }
            ScoreUpdatedDate = result.ScoreUpdatedDate == 0 ? null : (DateTime?)result.ScoreUpdatedDate.ToDateTime();
            ExposureDetails = new List<IExposureDetails>();
            if (result.ExposureDetails != null)
            {
                ExposureDetails.AddRange(from ed in result.ExposureDetails
                                         select new ExposureDetails(ed));
            }
        }

        public string UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Comment { get; set; }
        public DateTime? LastActivity { get; set; }
        public RiskScore? Score { get; set; }
        public DateTime? ScoreUpdatedDate { get; set; }
        public List<IExposureDetails> ExposureDetails { get; set; }
    }
}
