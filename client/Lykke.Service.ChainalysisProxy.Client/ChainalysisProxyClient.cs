using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                return MapUserScoreDetails(result.Body);
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
                return MapUserScoreDetails(result.Body);
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
                return MapUserScoreDetails((AutorestClient.Models.IUserScoreDetails)result.Body);
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
                return MapUserScoreDetails((AutorestClient.Models.IUserScoreDetails)result.Body);
            }

            return null;
        }

        private UserScoreDetails MapUserScoreDetails(AutorestClient.Models.IUserScoreDetails userDetails)
        {
            if(userDetails == null)
            {
                return null;
            }

            var result = new UserScoreDetails
            {
                UserId = userDetails.UserId,
                CreationDate = userDetails.CreationDate,
                Comment = userDetails.Comment,
                LastActivity = userDetails.LastActivity,
                Score = userDetails.Score == null ? (RiskScore?)null : (RiskScore)Enum.Parse(typeof(RiskScore), userDetails.Score.ToString(), true),
                ScoreUpdatedDate = userDetails.ScoreUpdatedDate,
                ExposureDetails = userDetails.ExposureDetails == null ? 
                                             new List<ExposureDetails>() :
                                             new List<ExposureDetails>(userDetails.ExposureDetails.Select(ex=>MapExposureDetails(ex)))
            };


            return result;
        }

        private ExposureDetails MapExposureDetails(AutorestClient.Models.IExposureDetails exposureDetails)
        {
            return new ExposureDetails
            {
                Category = exposureDetails.Category,
                SentIndirectExposure = exposureDetails.SentIndirectExposure,
                SentDirectExposure = exposureDetails.SentDirectExposure,
                ReceivedIndirectExposure = exposureDetails.ReceivedIndirectExposure,
                ReceivedDirectExposure = exposureDetails.ReceivedDirectExposure
            };
        }
    }
}
