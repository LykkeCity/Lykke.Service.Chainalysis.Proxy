using System.Threading.Tasks;
using Lykke.Service.ChainalysisProxy.Contracts;
using Lykke.Service.ChainalysisProxy.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lykke.Service.ChainalysisProxy.Controllers
{
    [Route("api/chainalysis")]
    public class ChainalysisController : Controller
    {
        /// <summary>
        /// Resigter user for track
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalisys)</param>
        /// <returns></returns>
        [HttpPost("/user/{userId}/register")]
        [SwaggerResponse(200, typeof(object), "Successful response")]
        public async Task<IActionResult> RegisterUser(string userId)
        {
            return Ok();
        }

        /// <summary>
        /// Get Information about user
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalisys)</param>
        /// <returns>Information about user</returns>
        [HttpGet("/user/{userId}/get")]
        [SwaggerResponse(200, typeof(IUserScoreDetails), "Successful response")]
        [SwaggerResponse(404, typeof(object), "User not found")]
        public async Task<IActionResult> GetUserScore(string userId)
        {
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalisys)</param>
        /// <param name="transaction">Transaction to be added</param>
        /// <returns>Information about user</returns>
        [HttpPost("/user/{userId}/addtransaction")]
        [SwaggerResponse(200, typeof(IUserScoreDetails), "Successful response")]
        [SwaggerResponse(404, typeof(object), "User not found")]
        [SwaggerResponse(400, typeof(object), "Internal error")]
        public async Task<IActionResult> AddTransaction(string userId, [FromBody] NewTransactionModel transaction)
        {
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalisys)</param>
        /// <param name="wallet">Wallet to be added</param>
        /// <returns>Information about user</returns>
        [HttpPost("/user/{userId}/addwallet")]
        [SwaggerResponse(200, typeof(IUserScoreDetails), "Successful response")]
        [SwaggerResponse(404, typeof(object), "User not found")]
        [SwaggerResponse(400, typeof(object), "Internal error")]
        public async Task<IActionResult> AddWallet(string userId, [FromBody] NewWalletModel wallet)
        {
            return Ok();
        }
    }
}
