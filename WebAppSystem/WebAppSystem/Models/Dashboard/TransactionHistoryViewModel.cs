using WebAppSystem.Models.Transactions;

namespace WebAppSystem.Models.Dashboard
{
    public class TransactionHistoryViewModel
    {
        public IEnumerable<TransactionViewModel> SendTransactions { get; set; }
        public IEnumerable<TransactionViewModel> ReceivedTransactions { get; set; }
    }
}
