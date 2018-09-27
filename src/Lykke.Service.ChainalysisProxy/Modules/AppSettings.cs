using Lykke.Sdk.Settings;
using Lykke.Service.ChainalysisProxy.Modules.ServiceSettings;

namespace Lykke.Service.ChainalysisProxy.Modules
{
    public class AppSettings : BaseAppSettings
    {
        public ChainalysisProxySettings ChainalysisProxyService { get; set; }
    }
}
