namespace WebAppSystem.Repository
{
    using WebAppSystem.Data;
    using WebAppSystem.Data.Models;

    public class TransactionRepository : ITransactionRepository
    {
        private ApplicationDbContext dbContext;

        public TransactionRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Is AddTransaction better name?
        public void CreateTransaction(Transaction transaction)
        {
            this.dbContext.Add(transaction);
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return this.dbContext.Transactions.ToList();
        }

        public Transaction GetTransactionById(int transactionId)
        {
            // FirstOrDefault or Find?
            return this.dbContext.Transactions.FirstOrDefault(t => t.Id == transactionId);
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}
