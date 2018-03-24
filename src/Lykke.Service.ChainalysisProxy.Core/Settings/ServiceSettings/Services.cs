using System;
using System.Collections.Generic;
using System.Text;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.ChainalysisProxy.Core.Settings.ServiceSettings
{
    public class Services
    {
        [HttpCheck("/swagger/ui")]
        public string CainalisysUrl { get; set; }
        public string CainalisysKey { get; set; }
    }
}
