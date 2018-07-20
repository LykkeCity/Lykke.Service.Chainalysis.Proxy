using System;
using System.Globalization;
using Lykke.Service.ChainalysisProxy.Core.Domain;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Service.ChainalysisProxy.AzureRepositories
{
    public class TransactionStatus : TableEntity, ITransactionStatus
    {

        public TransactionStatus()
        {
            ETag = "*";
        }

        private string _btcTransactionHash;
        private int _outputNumber;

        public TransactionStatus(ITransactionStatus item)
        {
            ClientId = item.ClientId;
            TransactionHash = item.TransactionHash;
            WalletAddress = item.WalletAddress;
            OutputNumber = item.OutputNumber;
            TransactionAmount = item.TransactionAmount;
            ChainalysisCategory = item.ChainalysisCategory;
            ChainalysisName = item.ChainalysisName;
            ChainalysisRiskScore = item.ChainalysisRiskScore;
        }

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
        [IgnoreProperty]
        public RiskScore ChainalysisRiskScore { get => (RiskScore)Enum.Parse(typeof(RiskScore), ChainalysisScore); set=>ChainalysisScore = value.ToString(); }

    }
}
