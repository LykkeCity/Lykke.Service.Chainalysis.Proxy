
namespace Lykke.Service.ChainalysisProxy.Core.Domain
{
    public interface INewWalletModel
    {
        string Address { get; set; }

        WalletType WalletType { get; set; }
    }
}
