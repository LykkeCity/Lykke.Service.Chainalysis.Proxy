// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Service.ChainalysisProxy.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ChainalysisUserModel
    {
        /// <summary>
        /// Initializes a new instance of the ChainalysisUserModel class.
        /// </summary>
        public ChainalysisUserModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ChainalysisUserModel class.
        /// </summary>
        public ChainalysisUserModel(string userId = default(string))
        {
            UserId = userId;
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

    }
}
