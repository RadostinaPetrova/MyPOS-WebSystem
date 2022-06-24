namespace WebAppSystem.Repository
{
    using WebAppSystem.Data.Models;

    public interface ITransactionRepository
    {
        void CreateTransaction(Transaction transaction);

        void SaveChanges();

        Transaction GetTransactionById(int transactionId);

        IEnumerable<Transaction> GetAllTransactions();
    }
}
