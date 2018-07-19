using System;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Common.Log;
using Lykke.Service.ChainalysisProxy.Contracts;
using Lykke.Service.ChainalysisProxy.Core.Domain;
using Lykke.Service.ChainalysisProxy.Core.Services;
using Lykke.Service.ChainalysisProxy.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lykke.Service.ChainalysisProxy.Controllers
{
    [Route("api/chainalysis")]
    public class ChainalysisController : Controller
    {
        private readonly IChainalysisProxyService _service;
        private readonly ILog _log;

        public ChainalysisController(IChainalysisProxyService service, ILog log)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }
        /// <summary>
        /// Resigter user for track
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalysis)</param>
        /// <returns></returns>
        [HttpPost("/user/{userId}/register")]
        [SwaggerResponse(200, typeof(IUserScoreDetails), "Successful response")]
        public async Task<IActionResult> RegisterUser(string userId)
        {
            _log.WriteInfo(nameof(RegisterUser), "Input value", string.Format($"UserId = {userId}"));
            var result = await _service.RegisterUser(userId);
            _log.WriteInfo(nameof(RegisterUser), "Result", result.ToJson());
            return Ok(result);
        }

        /// <summary>
        /// Get Information about user
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalysis)</param>
        /// <returns>Information about user</returns>
        [HttpGet("/user/{userId}/get")]
        [SwaggerResponse(200, typeof(IUserScoreDetails), "Successful response")]
        [SwaggerResponse(400, typeof(object), "Not Found")]
        public async Task<IActionResult> GetUserScore(string userId)
        {
            _log.WriteInfo(nameof(GetUserScore), "Input value", string.Format($"UserId = {userId}"));
            Guid userGuid;
            if (!Guid.TryParse(userId, out userGuid))
            {
                _log.WriteInfo(nameof(GetUserScore), "Bad request", "");
                return BadRequest();
            }
            var result = await _service.GetUserScore(userId);
            if (result == null)
            {
                _log.WriteWarning(nameof(GetUserScore), "Result", "Null");
                return Ok(string.Empty);
            }

            _log.WriteInfo(nameof(GetUserScore), "Result", result.ToJson());


            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalysis)</param>
        /// <param name="transaction">Transaction to be added</param>
        /// <returns>Information about user</returns>
        [HttpPost("/user/{userId}/addtransaction")]
        [SwaggerResponse(200, typeof(INewTransactionModel), "Successful response")]
        [SwaggerResponse(400, typeof(object), "Internal error")]
        public async Task<IActionResult> AddTransaction(string userId, [FromBody]   ChainalysisProxy.Contracts.NewTransactionModel transaction)
        {
            _log.WriteInfo(nameof(AddTransaction), "Input value", string.Format($"UserId = {userId}, Transaction = ") + transaction.ToJson());
            var trans = Mapper.Map<Models.NewTransactionModel>(transaction);
            await _service.AddTransaction(userId, trans);
            _log.WriteInfo(nameof(AddTransaction), "Result", trans.ToJson());
            return Ok(trans);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">Lykke user Id </param>
        /// <returns>Chainalysis user Id</returns>
        [HttpGet("/user/{userId}/getChainalysisId")]
        [SwaggerResponse(200, typeof(ChainalysisUserModel), "Successful response")]
        [SwaggerResponse(400, typeof(object), "Internal error")]
        public async Task<IActionResult> GetChainalysisId(string userId)
        {
            _log.WriteInfo(nameof(GetChainalysisId), "Input value", string.Format($"UserId = {userId}"));
            Guid userGuid;
            if (!Guid.TryParse(userId, out userGuid))
            {
                _log.WriteWarning(nameof(GetChainalysisId), "Bad request", "");
                return BadRequest();
            }
            var result = new ChainalysisUserModel { UserId = await _service.GetChainalysisId(userId) };
            _log.WriteInfo(nameof(GetChainalysisId), "Result", result.ToJson());
            return Ok(result);
        }



        [HttpGet("/transactionByClientId/{clientId}/wallet/{wallet}")]
        [SwaggerResponse(200, typeof(ITransactionStatus), "Successful response")]
        [SwaggerResponse(400, typeof(object), "Internal error")]
        public async Task<IActionResult> GetTransactionStatus(string clientId, string wallet)
        {
            _log.WriteInfo(nameof(GetTransactionStatus), "Input value", string.Format($"clientId = {clientId}, wallet = {wallet}"));
            Guid clientGuidId;
            if (!Guid.TryParse(clientId, out clientGuidId))
            {
                _log.WriteWarning(nameof(GetChainalysisId), "Bad request", "");
                return BadRequest();
            }
            var result = await _service.GetTransactionsByClientIdAndWalletAsync(clientId, wallet);
            _log.WriteInfo(nameof(GetTransactionStatus), "Result", result.ToJson());
            return Ok(result);
        }


    }
}
