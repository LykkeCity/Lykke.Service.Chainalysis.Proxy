using System.Threading.Tasks;

namespace Lykke.Service.ChainalysisProxy.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}