// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Service.ChainalysisProxy.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class IUserScoreDetails
    {
        /// <summary>
        /// Initializes a new instance of the IUserScoreDetails class.
        /// </summary>
        public IUserScoreDetails()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the IUserScoreDetails class.
        /// </summary>
        /// <param name="score">Possible values include: 'Red', 'Amber',
        /// 'Green'</param>
        public IUserScoreDetails(System.DateTime creationDate, System.DateTime lastActivity, System.DateTime scoreUpdatedDate, string userId = default(string), string comment = default(string), RiskScore? score = default(RiskScore?), IList<IExposureDetails> exposureDetails = default(IList<IExposureDetails>))
        {
            UserId = userId;
            CreationDate = creationDate;
            Comment = comment;
            LastActivity = lastActivity;
            Score = score;
            ScoreUpdatedDate = scoreUpdatedDate;
            ExposureDetails = exposureDetails;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UserId")]
        public string UserId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CreationDate")]
        public System.DateTime CreationDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Comment")]
        public string Comment { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "LastActivity")]
        public System.DateTime LastActivity { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Red', 'Amber', 'Green'
        /// </summary>
        [JsonProperty(PropertyName = "Score")]
        public RiskScore? Score { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ScoreUpdatedDate")]
        public System.DateTime ScoreUpdatedDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ExposureDetails")]
        public IList<IExposureDetails> ExposureDetails { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ExposureDetails != null)
            {
                foreach (var element in ExposureDetails)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
