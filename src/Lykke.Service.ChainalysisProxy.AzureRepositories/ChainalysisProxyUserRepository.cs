using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AzureStorage;
using Lykke.Service.ChainalysisProxy.Core.Repositories;

namespace Lykke.Service.ChainalysisProxy.AzureRepositories
{
    public class ChainalysisProxyUserRepository : IChainalysisProxyUserRepository
    {
        private readonly INoSQLTableStorage<ProxyUser> _repository;

        public ChainalysisProxyUserRepository(INoSQLTableStorage<ProxyUser> repository)
        {
            _repository = repository;
        }

        public async Task<string> GetUser(string lykkeUserId, bool createIfNotExists = true)
        {
            if (string.IsNullOrEmpty(lykkeUserId))
            {
                throw new ArgumentNullException(nameof(lykkeUserId));
            }
            var result = await _repository.GetDataAsync(ProxyUser.GetPartitionKey(), lykkeUserId);
            if (result == null && createIfNotExists)
            {
                result = new ProxyUser
                {
                    PartitionKey = ProxyUser.GetPartitionKey(),
                    LykkeUserId = lykkeUserId,
                    UserId = Guid.NewGuid().ToString()
                };
                await _repository.InsertOrMergeAsync(result);
            }

            return result?.UserId;
        }
    }
}
