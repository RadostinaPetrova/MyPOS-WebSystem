namespace WebAppSystem.Repository
{
    using WebAppSystem.Data.Models;

    public interface ITransactionRepository
    {
        // Is AddTransaction better name?
        void CreateTransaction(Transaction transaction);

        void SaveChanges();

        Transaction GetTransactionById(int transactionId);

        IEnumerable<Transaction> GetAllTransactions();
    }
}
