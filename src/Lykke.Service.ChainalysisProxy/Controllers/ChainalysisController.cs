using System.Threading.Tasks;
using AutoMapper;
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

        public ChainalysisController(IChainalysisProxyService service)
        {
            _service = service;
        }
        /// <summary>
        /// Resigter user for track
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalisys)</param>
        /// <returns></returns>
        [HttpPost("/user/{userId}/register")]
        [SwaggerResponse(200, typeof(IUserScoreDetails), "Successful response")]
        public async Task<IActionResult> RegisterUser(string userId)
        {
            var result = await _service.RegisterUser(userId);
            return Ok(result);
        }

        /// <summary>
        /// Get Information about user
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalisys)</param>
        /// <returns>Information about user</returns>
        [HttpGet("/user/{userId}/get")]
        [SwaggerResponse(200, typeof(IUserScoreDetails), "Successful response")]
        public async Task<IActionResult> GetUserScore(string userId)
        {
            var result = await _service.GetUserScore(userId);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalisys)</param>
        /// <param name="transaction">Transaction to be added</param>
        /// <returns>Information about user</returns>
        [HttpPost("/user/{userId}/addtransaction")]
        [SwaggerResponse(200, typeof(IUserScoreDetails), "Successful response")]
        [SwaggerResponse(400, typeof(object), "Internal error")]
        public async Task<IActionResult> AddTransaction(string userId, [FromBody]   ChainalysisProxy.Contracts.NewTransactionModel transaction)
        {
            var result = await _service.AddTransaction(userId, Mapper.Map<NewTransactionModel>(transaction));
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalisys)</param>
        /// <param name="wallet">Wallet to be added</param>
        /// <returns>Information about user</returns>
        [HttpPost("/user/{userId}/addwallet")]
        [SwaggerResponse(200, typeof(IUserScoreDetails), "Successful response")]
        [SwaggerResponse(400, typeof(object), "Internal error")]
        public async Task<IActionResult> AddWallet(string userId, [FromBody] ChainalysisProxy.Contracts.NewWalletModel wallet)
        {
            var result = await _service.AddWallet(userId, Mapper.Map<NewWalletModel>(wallet));
            return Ok(result);
        }
    }
}
