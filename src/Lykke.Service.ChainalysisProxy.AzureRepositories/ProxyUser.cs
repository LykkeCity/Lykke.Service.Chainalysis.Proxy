using AzureStorage.Tables;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Service.ChainalysisProxy.AzureRepositories
{
    public class ProxyUser : TableEntity
    {
        public ProxyUser()
        {
            ETag = "*";
        }

        public static string GetPartitionKey()
        {
            return "PU";
        }

        public string LykkeUserId
        {
            get => RowKey;
            set => RowKey = value;
        }

        public string UserId { get; set; }
    }
}
