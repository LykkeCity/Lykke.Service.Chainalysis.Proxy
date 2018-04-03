// Code generated by Microsoft (R) AutoRest Code Generator 1.1.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Lykke.Service.ChainalysisProxy.AutorestClient.Models
{
    using Lykke.Service;
    using Lykke.Service.ChainalysisProxy;
    using Lykke.Service.ChainalysisProxy.AutorestClient;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class NewTransactionModel
    {
        /// <summary>
        /// Initializes a new instance of the NewTransactionModel class.
        /// </summary>
        public NewTransactionModel()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NewTransactionModel class.
        /// </summary>
        /// <param name="transactionType">Possible values include: 'Reseived',
        /// 'Sent'</param>
        public NewTransactionModel(int output, TransactionType transactionType, string transaction = default(string))
        {
            Transaction = transaction;
            Output = output;
            TransactionType = transactionType;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Transaction")]
        public string Transaction { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Output")]
        public int Output { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Reseived', 'Sent'
        /// </summary>
        [JsonProperty(PropertyName = "TransactionType")]
        public TransactionType TransactionType { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
        }
    }
}
