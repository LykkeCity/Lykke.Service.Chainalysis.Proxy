using System;

namespace Lykke.Service.ChainalysisProxy.Services
{
    public static class UnixDateTimeExtention
    {
        public static DateTime ToDateTime(this long unixDateTime)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixDateTime).ToLocalTime();
            return dtDateTime;
        }
    }
}
