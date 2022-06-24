namespace WebAppSystem.Services
{
    using WebAppSystem.Models.Transactions;

    public interface ITransactionService
    {
        void CreateTransaction(TransactionInputModel transaction, string userId);

        ICollection<TransactionViewModel> SentTransactions(string userId);

        ICollection<TransactionViewModel> ReceivedTransactions(string userId);

        IEnumerable<TransactionViewModel> GetAll();
    }
}
