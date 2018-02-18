using System;
using Common.Log;

namespace Lykke.Service.ChainalysisProxy.Client
{
    public class ChainalysisProxyClient : IChainalysisProxyClient, IDisposable
    {
        private readonly ILog _log;

        public ChainalysisProxyClient(string serviceUrl, ILog log)
        {
            _log = log;
        }

        public void Dispose()
        {
            //if (_service == null)
            //    return;
            //_service.Dispose();
            //_service = null;
        }
    }
}
