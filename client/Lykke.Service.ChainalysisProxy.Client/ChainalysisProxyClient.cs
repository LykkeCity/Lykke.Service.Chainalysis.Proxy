using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Common.Log;
using Lykke.Service.ChainalysisProxy.Contracts;

namespace Lykke.Service.ChainalysisProxy.Client
{
    /// <summary>
    /// Chainalysis Proxy Client
    /// </summary>
    public class ChainalysisProxyClient : IChainalysisProxyClient
    {
        private readonly ILog _log;
        private int _timeout;

        /// <summary>
        /// Chainalysis Proxy Client
        /// </summary>
        /// <param name="serviceUrl"></param>
        /// <param name="logFactory"></param>
        /// /// <param name="timeout"></param>
        public ChainalysisProxyClient(string serviceUrl, ILogFactory logFactory, int timeout)
        {
            if (logFactory == null)
                throw new ArgumentNullException(nameof(logFactory));
            _log = logFactory.CreateLog(this);

            if (string.IsNullOrWhiteSpace(serviceUrl))
                throw new ArgumentNullException(nameof(serviceUrl));
            
            _timeout = timeout;
        }
        
        public async Task<UserScoreDetails> GetUserScore(string userId)
        {            
            return null; // TODO: use refit
        }
        
        public async Task<TransactionStatusResult> GetTransactionsStatus(Guid clientId, string walletAddress)
        {
            return null; // TODO: use refit
        }      
    }
}
