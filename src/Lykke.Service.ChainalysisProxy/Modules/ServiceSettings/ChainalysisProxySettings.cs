using Lykke.Service.ChainalysisProxy.Core.Settings.ServiceSettings;

namespace Lykke.Service.ChainalysisProxy.Modules.ServiceSettings
{
    public class ChainalysisProxySettings
    {
        public DbSettings Db { get; set; }
        public ChainalysisSettings Chainalysis { get; set; }
    }
}
