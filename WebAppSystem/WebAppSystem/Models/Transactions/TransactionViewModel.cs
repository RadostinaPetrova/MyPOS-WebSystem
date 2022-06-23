namespace WebAppSystem.Models.Transactions
{
    public class TransactionViewModel
    {
        public int CreditAmount { get; set; }

        public string Message { get; set; }

        public string RecipientName { get; set; }

        public string SenderName { get; set; }

        public DateTime Date { get; set; }
    }
}
