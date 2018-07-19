using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.ChainalysisProxy.Core.Domain;

namespace Lykke.Service.ChainalysisProxy.Core.Repositories
{
    public interface IChainalysisTransactionStatusRepository
    {
        Task<IReadOnlyList<ITransactionStatus>> GetTransactionsByClientIdAsync(string wallet);
    }
}
