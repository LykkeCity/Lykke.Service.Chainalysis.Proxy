using System.Threading.Tasks;

namespace Lykke.Service.ChainalysisProxy.Core.Repositories
{
    public interface IChainalysisProxyUserRepository
    {
        /// <summary>
        /// Get Chainalysis user id base on lykke user id. If the user is not exist - create it.
        /// </summary>
        /// <param name="lykkeUserId">Lykke user id</param>
        /// <returns></returns>
        Task<string> GetUser(string lykkeUserId, bool createIfNotExists = true);

    }
}
