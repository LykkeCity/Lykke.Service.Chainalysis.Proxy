using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureStorage;
using System.Linq;

namespace Lykke.Service.ChainalysisProxy.AzureRepositories
{
    public class ChainalysisTransactionStatusRepository : IChainalysisTransactionStatusRepository
    {
        private readonly INoSQLTableStorage<TransactionStatusEntity> _repository;

        public ChainalysisTransactionStatusRepository(INoSQLTableStorage<TransactionStatusEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TransactionStatusEntity>> GetTransactionsByClientIdAsync(Guid wallet)
        {
            var result = await _repository.GetDataAsync(wallet.ToString());
            return result.ToList();
        }
    }
}
