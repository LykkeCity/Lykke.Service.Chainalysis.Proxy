/*using System;
using Lykke.Service.ChainalysisProxy.AutorestClient.Models;

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
        public static NewTransactionModel Map(this Contracts.NewTransactionModel model)
        {
            if(model == null)
            {
                return null;
            }
            return new NewTransactionModel(model.Output,
                                                                 (TransactionType)Enum.Parse(typeof(TransactionType), model.TransactionType.ToString(), true),
                                                                 model.Transaction);
                
        }


        /// <summary>
        /// Map new Wallet Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static NewWalletModel Map(this Contracts.NewWalletModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new NewWalletModel((WalletType)Enum.Parse(typeof(WalletType), model.WalletType.ToString(), true),
                                                            model.Address);
        }


    }
}
*/