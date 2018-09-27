using System;
using System.Threading.Tasks;
using Common;
using Common.Log;
using Lykke.Common.Log;
using Lykke.Service.ChainalysisProxy.Contracts;
using Lykke.Service.ChainalysisProxy.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lykke.Service.ChainalysisProxy.Controllers
{
    [Route("api/chainalysis")]
    public class ChainalysisController : Controller
    {
        private readonly IChainalysisProxyService _service;
        private readonly ILog _log;

        public ChainalysisController(IChainalysisProxyService service, ILogFactory log)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _log = log.CreateLog(this) ?? throw new ArgumentNullException(nameof(log));
        }
        
        [HttpGet("/user/{userId}/get")]
        [SwaggerResponse(200, typeof(UserScoreDetails), "Successful response")]
        [SwaggerResponse(400, typeof(object), "Not Found")]
        public async Task<IActionResult> GetUserScore(Guid userId)
        {
            var result = await _service.GetUserScore(userId);

            if (result == null)
                return NotFound();

#if DEBUG
            _log.Info(nameof(GetUserScore), result.ToJson(), $"User score fetched for ID {userId}");
#endif

            return Ok(result);
        }
        

        [HttpGet("/transactionByClientId/{clientId}/wallet/{wallet}")]
        [SwaggerResponse(200, typeof(TransactionStatusResult), "Successful response")]
        [SwaggerResponse(400, typeof(object), "Internal error")]
        public async Task<IActionResult> GetTransactionStatus(Guid clientId, Guid wallet)
        {
            var result = new TransactionStatusResult { Transactions = await _service.GetTransactionsByClientIdAndWalletAsync(clientId, wallet) };
            
            return Ok(result);
        }
    }
}
