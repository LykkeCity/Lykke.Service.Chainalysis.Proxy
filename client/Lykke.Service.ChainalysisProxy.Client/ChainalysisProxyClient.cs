using System;
using System.Threading.Tasks;
using AutoMapper;
using Common.Log;
using Lykke.Service.ChainalysisProxy.Client.AutorestClient;
using Lykke.Service.ChainalysisProxy.Contracts;

namespace Lykke.Service.ChainalysisProxy.Client
{
    public class ChainalysisProxyClient : IChainalysisProxyClient, IDisposable
    {
        private readonly ILog _log;
        private IChainalysisProxyAPI _service;

        public ChainalysisProxyClient(string serviceUrl, ILog log)
        {
            _log = log;
            _service = new ChainalysisProxyAPI(new Uri(serviceUrl));
        }

        public void Dispose()
        {
            if (_service == null)
                return;
            _service.Dispose();
            _service = null;
        }

        public async Task<UserScoreDetails> RegisterUser(string userId)
        {
            var result = await _service.UserByUserIdRegisterPostWithHttpMessagesAsync(userId);
            if (result.Response.IsSuccessStatusCode)
            {
                return Mapper.Map<UserScoreDetails>(result.Body);
            }

            return null;

        }

        public async Task<UserScoreDetails> GetUserScore(string userId)
        {
            var result = await _service.UserByUserIdGetGetWithHttpMessagesAsync(userId);
            if (result.Response.IsSuccessStatusCode)
            {
                return Mapper.Map<UserScoreDetails>(result.Body);
            }

            return null;
        }

        public async Task<UserScoreDetails> AddTransaction(string userId, NewTransactionModel transaction)
        {
            var result = await _service.UserByUserIdAddtransactionPostWithHttpMessagesAsync(userId, transaction.Map());
            if (result.Response.IsSuccessStatusCode)
            {
                return Mapper.Map<UserScoreDetails>(result.Body);
            }

            return null;
        }

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
