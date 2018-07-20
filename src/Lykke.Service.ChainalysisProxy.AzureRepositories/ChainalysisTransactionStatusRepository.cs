using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.ChainalysisProxy.Core.Domain;
using AzureStorage;
using Lykke.Service.ChainalysisProxy.Core.Repositories;
using System.Linq;

namespace Lykke.Service.ChainalysisProxy.AzureRepositories
{
    public class ChainalysisTransactionStatusRepository : IChainalysisTransactionStatusRepository
    {
        private readonly INoSQLTableStorage<TransactionStatus> _repository;

        public ChainalysisTransactionStatusRepository(INoSQLTableStorage<TransactionStatus> repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<ITransactionStatus>> GetTransactionsByClientIdAsync(string wallet)
        {
            var result = await _repository.GetDataAsync(wallet);
            return result.ToList();
        }
    }
}
