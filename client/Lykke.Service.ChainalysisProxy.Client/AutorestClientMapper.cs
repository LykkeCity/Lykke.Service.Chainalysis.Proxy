using AutoMapper;

namespace Lykke.Service.ChainalysisProxy.Client
{
    /// <summary>
    /// Autorest Client Mapper
    /// </summary>
    public static class AutorestClientMapper
    {
        /// <summary>
        /// Map New transaction Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AutorestClient.Models.NewTransactionModel Map(this Contracts.NewTransactionModel model)
        {
            return Mapper.Map<AutorestClient.Models.NewTransactionModel>(model);
        }


        /// <summary>
        /// Map new Wallet Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AutorestClient.Models.NewWalletModel Map(this Contracts.NewWalletModel model)
        {
            return Mapper.Map<AutorestClient.Models.NewWalletModel>(model);
        }


    }
}
