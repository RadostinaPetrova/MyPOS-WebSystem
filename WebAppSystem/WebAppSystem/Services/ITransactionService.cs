namespace WebAppSystem.Services
{
    using WebAppSystem.Models.Transactions;

    public interface ITransactionService
    {
        void CreateTransaction(TransactionInputModel transaction, string userId);

        IEnumerable<TransactionViewModel> SentTransactions(string userId);

        IEnumerable<TransactionViewModel> ReceivedTransactions(string userId);

        IEnumerable<TransactionViewModel> GetAll();
    }
}
