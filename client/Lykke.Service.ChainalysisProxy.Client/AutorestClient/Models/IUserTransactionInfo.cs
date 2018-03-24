// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Service.ChainalysisProxy.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class IUserTransactionInfo
    {
        /// <summary>
        /// Initializes a new instance of the IUserTransactionInfo class.
        /// </summary>
        public IUserTransactionInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the IUserTransactionInfo class.
        /// </summary>
        public IUserTransactionInfo(int? total = default(int?), int? limit = default(int?), int? offset = default(int?), IList<ITransactionInfo> data = default(IList<ITransactionInfo>))
        {
            Total = total;
            Limit = limit;
            Offset = offset;
            Data = data;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int? Total { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "offset")]
        public int? Offset { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public IList<ITransactionInfo> Data { get; set; }

    }
}