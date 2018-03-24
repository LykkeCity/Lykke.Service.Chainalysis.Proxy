using Lykke.SettingsReader.Attributes;
namespace Lykke.Service.ChainalysisProxy.Core.Settings.ServiceSettings
{
    public class DbSettings
    {
        [AzureTableCheck]
        public string LogsConnString { get; set; }
        [AzureTableCheck]
        public string DataConnString { get; set; }
    }
}
