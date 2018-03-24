using System;
using System.Threading.Tasks;
using AutoMapper;
using Common.Log;
using Lykke.Service.ChainalysisProxy.Client.AutorestClient;
using Lykke.Service.ChainalysisProxy.Contracts;

namespace Lykke.Service.ChainalysisProxy.Client
{
    /// <summary>
    /// Chainalysis Proxy Client
    /// </summary>
    public class ChainalysisProxyClient : IChainalysisProxyClient, IDisposable
    {
        private readonly ILog _log;
        private IChainalysisProxyAPI _service;

        /// <summary>
        /// Chainalysis Proxy Client
        /// </summary>
        /// <param name="serviceUrl"></param>
        /// <param name="log"></param>
        public ChainalysisProxyClient(string serviceUrl, ILog log)
        {
            _log = log;
            _service = new ChainalysisProxyAPI(new Uri(serviceUrl));
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (_service == null)
                return;
            _service.Dispose();
            _service = null;
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserScoreDetails> RegisterUser(string userId)
        {
            var result = await _service.UserByUserIdRegisterPostWithHttpMessagesAsync(userId);
            if (result.Response.IsSuccessStatusCode)
            {
                return Mapper.Map<UserScoreDetails>(result.Body);
            }

            return null;

        }

        /// <summary>
        /// Get User Score
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserScoreDetails> GetUserScore(string userId)
        {
            var result = await _service.UserByUserIdGetGetWithHttpMessagesAsync(userId);
            if (result.Response.IsSuccessStatusCode)
            {
                return Mapper.Map<UserScoreDetails>(result.Body);
            }

            return null;
        }

        /// <summary>
        /// Add Transaction
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<UserScoreDetails> AddTransaction(string userId, NewTransactionModel transaction)
        {
            var result = await _service.UserByUserIdAddtransactionPostWithHttpMessagesAsync(userId, transaction.Map());
            if (result.Response.IsSuccessStatusCode)
            {
                return Mapper.Map<UserScoreDetails>(result.Body);
            }

            return null;
        }

        /// <summary>
        /// Add Wallet
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="wallet"></param>
        /// <returns></returns>
        public async Task<UserScoreDetails> AddWallet(string userId, NewWalletModel wallet)
        {
            var result = await _service.UserByUserIdAddwalletPostWithHttpMessagesAsync(userId, wallet.Map());
            if (result.Response.IsSuccessStatusCode)
            {
                return Mapper.Map<UserScoreDetails>(result.Body);
            }

            return null;
        }
    }
}
