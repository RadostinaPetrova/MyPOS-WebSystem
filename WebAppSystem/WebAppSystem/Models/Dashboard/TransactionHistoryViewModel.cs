namespace WebAppSystem.Models.Dashboard
{
    using WebAppSystem.Models.Transactions;

    public class TransactionHistoryViewModel
    {
        public IEnumerable<TransactionViewModel> SendTransactions { get; set; }
        public IEnumerable<TransactionViewModel> ReceivedTransactions { get; set; }
    }
}
