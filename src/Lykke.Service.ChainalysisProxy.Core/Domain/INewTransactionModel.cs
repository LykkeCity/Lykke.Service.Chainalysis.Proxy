namespace Lykke.Service.ChainalysisProxy.Core.Domain
{
    public interface INewTransactionModel
    {
        string Transaction { get; set; }
        string Output { get; set; }
        TransactionType TransactionType { get; set; }
    }
}
