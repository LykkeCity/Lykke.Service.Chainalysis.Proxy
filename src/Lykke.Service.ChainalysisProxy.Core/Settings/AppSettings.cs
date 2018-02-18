using Lykke.Service.ChainalysisProxy.Core.Settings.ServiceSettings;
using Lykke.Service.ChainalysisProxy.Core.Settings.SlackNotifications;

namespace Lykke.Service.ChainalysisProxy.Core.Settings
{
    public class AppSettings
    {
        public ChainalysisProxySettings ChainalysisProxyService { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
    }
}
