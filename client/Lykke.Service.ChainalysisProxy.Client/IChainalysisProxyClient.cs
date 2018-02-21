
using System.Threading.Tasks;
using Lykke.Service.ChainalysisProxy.Client.AutorestClient.Models;

namespace Lykke.Service.ChainalysisProxy.Client
{
    public interface IChainalysisProxyClient
    {
        /// <summary>
        /// Resigter user for track
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalisys)</param>
        /// <returns></returns>
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
        
        public async Task<IActionResult> AddWallet(string userId, [FromBody] ChainalysisProxy.Contracts.NewWalletModel wallet)
        {
            var result = await _service.AddWallet(userId, Mapper.Map<NewWalletModel>(wallet));
            return Ok(result);
        }
    }
}
