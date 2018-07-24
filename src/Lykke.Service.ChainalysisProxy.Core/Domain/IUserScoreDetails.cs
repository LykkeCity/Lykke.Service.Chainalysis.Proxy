using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ChainalysisProxy.Core.Domain
{
    /// <summary>
    /// User Score Details
    /// </summary>
    public interface IUserScoreDetails
    {
        /// <summary>
        /// User Lykke Id
        /// </summary>
        string UserId { get; set; }

        /// <summary>
        /// Date when the user was created
        /// </summary>
        DateTime CreationDate { get; set; }

        /// <summary>
        /// Comment. Only if exists
        /// </summary>
        string Comment { get; set; }

        /// <summary>
        /// The last time the user sent or received value. Only included if the user has sent or received value.
        /// </summary>
        DateTime LastActivity { get; set; }

        /// <summary>
        /// The risk score of the user. E.g. red, amber, or green. Only included if the user has sent or received value
        /// </summary>
        RiskScore? Score { get; set; }

        /// <summary>
        ///  The last time the risk score has been updated. Only included if the user has sent or received value.
        /// </summary>
        DateTime ScoreUpdatedDate { get; set; }

        /// <summary>
        /// Detailed exposure data.Only included if the user has sent or received value.
        /// </summary>
        List<IExposureDetails> ExposureDetails { get; set; }

    }
}
