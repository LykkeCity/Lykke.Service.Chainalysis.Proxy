using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Service.ChainalysisProxy.AutorestClient;
using Lykke.Service.ChainalysisProxy.AutorestClient.Models;
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
        private int _timeout;

        /// <summary>
        /// Chainalysis Proxy Client
        /// </summary>
        /// <param name="serviceUrl"></param>
        /// <param name="log"></param>
        /// /// <param name="timeout"></param>
        public ChainalysisProxyClient(string serviceUrl, ILog log, int timeout)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log)); 
            if(string.IsNullOrEmpty(serviceUrl))
            {
                throw new ArgumentNullException(nameof(serviceUrl)); 
            }
            _service = new ChainalysisProxyAPI(new Uri(serviceUrl));
            _timeout = timeout;
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


        private async Task<Task> TaskWithDelay(Task task)
        {
            if(_timeout > 0)
            {
                return await Task.WhenAny(task, Task.Delay(TimeSpan.FromSeconds(_timeout)));
            }

            return await Task.WhenAny(task);
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserScoreDetails> RegisterUser(string userId)
        {
            var task = _service.UserByUserIdRegisterPostWithHttpMessagesAsync(userId);
            var resTask = await TaskWithDelay(task);
            if(resTask != task)
            {
                _log.WriteWarning(nameof(ChainalysisProxyClient), nameof(RegisterUser), $"Timeout with {userId}");
                return null;
            }

            var result = task.Result;

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
            var task = _service.UserByUserIdGetGetWithHttpMessagesAsync(userId);
            var resTask = await TaskWithDelay(task);
            if (resTask != task)
            {
                _log.WriteWarning(nameof(ChainalysisProxyClient), nameof(GetUserScore), $"Timeout with {userId}");
                return null;
            }

            var result = task.Result;
            if (result.Response.IsSuccessStatusCode)
            {
                return MapUserScoreDetails((IUserScoreDetails)result.Body);
            }

            return null;
        }

        /// <summary>
        /// Add Transaction
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<Contracts.NewTransactionModel> AddTransaction(string userId, Contracts.NewTransactionModel transaction)
        {
            var task =  _service.UserByUserIdAddtransactionPostWithHttpMessagesAsync(userId, transaction.Map());
            var resTask = await TaskWithDelay(task);
            if (resTask != task)
            {
                _log.WriteWarning(nameof(ChainalysisProxyClient), nameof(AddTransaction), $"Timeout with {transaction.Transaction}");
                return null;
            }

            var result = task.Result;
            if (result.Response.IsSuccessStatusCode)
            {
                return MapNewTransactionModel((INewTransactionModel)result.Body);
            }

            return null;
        }

        private Contracts.NewTransactionModel MapNewTransactionModel(INewTransactionModel transactionModel)
        {
            if (transactionModel == null)
            {
                return null;
            }

            var result = new Contracts.NewTransactionModel
            {
                Transaction = transactionModel.Transaction,
                Output = transactionModel.Output,
                TransactionType = (Contracts.TransactionType)Enum.Parse(typeof(Contracts.TransactionType), transactionModel.TransactionType.ToString()),
                OutName = transactionModel.OutName,
                OutScore = (transactionModel.OutScore == null ? (Contracts.RiskScore?)null : (Contracts.RiskScore)Enum.Parse(typeof(Contracts.RiskScore), transactionModel.OutScore, true)),
                OutCategory = transactionModel.OutCategory
            };


            return result;
        }

        private UserScoreDetails MapUserScoreDetails(IUserScoreDetails userDetails)
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
                Score = userDetails.Score == null ? (ChainalysisProxy.Contracts.RiskScore?)null : (ChainalysisProxy.Contracts.RiskScore)Enum.Parse(typeof(ChainalysisProxy.Contracts.RiskScore), userDetails.Score.ToString(), true),
                ScoreUpdatedDate = userDetails.ScoreUpdatedDate,
                ExposureDetails = userDetails.ExposureDetails == null ? 
                                             new List<ExposureDetails>() :
                                             new List<ExposureDetails>(userDetails.ExposureDetails.Select(ex=>MapExposureDetails(ex)))
            };


            return result;
        }

        private ExposureDetails MapExposureDetails(                                                                                                                                                                                                                                                                                    IExposureDetails exposureDetails)
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

        public async Task<Contracts.ChainalysisUserModel> GetChainalysisId(string userId)
        {
            var task =  _service.UserByUserIdGetChainalysisIdGetAsync(userId);
            var resTask = await TaskWithDelay(task);
            if (resTask != task)
            {
                _log.WriteWarning(nameof(ChainalysisProxyClient), nameof(GetChainalysisId), $"Timeout with {userId}");
                return null;
            }

            var result = task.Result;
            return new Contracts.ChainalysisUserModel { UserId = (result as ChainalysisProxy.AutorestClient.Models.ChainalysisUserModel)?.UserId };
        }

      
    }
}
