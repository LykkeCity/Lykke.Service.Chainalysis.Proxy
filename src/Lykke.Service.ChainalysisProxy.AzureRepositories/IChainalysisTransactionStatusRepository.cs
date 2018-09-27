using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Service.ChainalysisProxy.AzureRepositories
{
    public interface IChainalysisTransactionStatusRepository
    {
        Task<IEnumerable<TransactionStatusEntity>> GetTransactionsByClientIdAsync(Guid wallet);
    }
}
