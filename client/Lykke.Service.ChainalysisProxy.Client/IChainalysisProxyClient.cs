
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.ChainalysisProxy.Contracts;


namespace Lykke.Service.ChainalysisProxy.Client
{
    /// <summary>
    /// Chainalysis Proxy Client 
    /// </summary>
    public interface IChainalysisProxyClient
    {
        /// <summary>
        /// Get Information about user
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalysis)</param>
        /// <returns>Information about user</returns>

        Task<UserScoreDetails> GetUserScore(string userId);
        
        /// <summary>
        /// Get transaction by ClientId and WalletAddress.
        /// </summary>
        Task<TransactionStatusResult> GetTransactionsStatus(Guid clientId, string walletAddress);
    }
}
