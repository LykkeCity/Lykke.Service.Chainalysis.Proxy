using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.ChainalysisProxy.Contracts;

namespace Lykke.Service.ChainalysisProxy.Services
{
    public interface IChainalysisProxyService
    {
        Task<UserScoreDetails> GetUserScore(Guid userId);
        
        Task<IEnumerable<TransactionStatus>> GetTransactionsByClientIdAndWalletAsync(Guid clientId, Guid wallet);
    }
}
