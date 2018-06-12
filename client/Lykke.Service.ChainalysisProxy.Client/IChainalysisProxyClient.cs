
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
        /// Resigter user for track
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalysis)</param>
        /// <returns></returns>
        Task<UserScoreDetails> RegisterUser(string userId);

        /// <summary>
        /// Get Information about user
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalysis)</param>
        /// <returns>Information about user</returns>

        Task<UserScoreDetails> GetUserScore(string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalysis)</param>
        /// <param name="transaction">Transaction to be added</param>
        /// <returns>Information about user</returns>

        Task<UserScoreDetails> AddTransaction(string userId, Contracts.NewTransactionModel transaction);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">Lykke user Id (won't be use for Chainalysis)</param>
        /// <param name="wallet">Wallet to be added</param>
        /// <returns>Information about user</returns>

        Task<UserScoreDetails> AddWallet(string userId, Contracts.NewWalletModel wallet);

        /// <summary>
        /// Gets the Chainalysis identifier.
        /// </summary>
        /// <returns>The Chainalysis identifier.</returns>
        /// <param name="userId">User identifier.</param>

        Task<ChainalysisUserModel> GetChainalysisId(string userId);
    }
}
