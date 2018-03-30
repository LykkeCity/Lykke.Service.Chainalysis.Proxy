using System;


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
            if(model == null)
            {
                return null;
            }
            return new AutorestClient.Models.NewTransactionModel(model.Output,
                                                                 (AutorestClient.Models.TransactionType)Enum.Parse(typeof(AutorestClient.Models.TransactionType), model.TransactionType.ToString(), true),
                                                                 model.Transaction);
                
        }


        /// <summary>
        /// Map new Wallet Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AutorestClient.Models.NewWalletModel Map(this Contracts.NewWalletModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new AutorestClient.Models.NewWalletModel((AutorestClient.Models.WalletType)Enum.Parse(typeof(AutorestClient.Models.WalletType), model.WalletType.ToString(), true),
                                                            model.Address);
        }


    }
}
