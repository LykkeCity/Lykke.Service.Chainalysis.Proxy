using System.Globalization;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Service.ChainalysisProxy.AzureRepositories
{
    public class TransactionStatusEntity : TableEntity
    {

        public TransactionStatusEntity()
        {
            ETag = "*";
        }

        private string _btcTransactionHash;
        private int _outputNumber;
        
        private void UpdateRowKey()
        {
            RowKey = $"{_btcTransactionHash}:{_outputNumber}";
        }

        public string LwClientId { get; set; }
        public string BtcTransactionHash { get => _btcTransactionHash; set { _btcTransactionHash = value; UpdateRowKey(); } }
        public string WalletAddress { get => PartitionKey; set => PartitionKey = value; }
        public int OutputNumber { get => _outputNumber; set { _outputNumber = value; UpdateRowKey(); } }
        [IgnoreProperty]
        public decimal TransactionAmount { get; set; }
        public string ChainalysisCategory { get; set; }
        public string ChainalysisName { get; set; }

        public string ChainalysisScore { get; set; }
        [IgnoreProperty]
        public string ClientId { get => LwClientId; set => LwClientId = value; }
        [IgnoreProperty]
        public string TransactionHash { get => BtcTransactionHash; set => BtcTransactionHash = value; }

        public string Amount { get => TransactionAmount.ToString("N8", CultureInfo.InvariantCulture); set=>  TransactionAmount = decimal.Parse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);}
    }
}
