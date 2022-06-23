namespace WebAppSystem.Services
{
    using System.Collections.Generic;
    using WebAppSystem.Data.Models;
    using WebAppSystem.Models.Transactions;
    using WebAppSystem.Repository;

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionsRepository;
        private readonly IUserRepository usersRepository;

        public TransactionService(ITransactionRepository transactionsRepository, IUserRepository usersRepository)
        {
            this.transactionsRepository = transactionsRepository;
            this.usersRepository = usersRepository;
        }

        public void CreateTransaction(TransactionInputModel input, string userId)
        {
            var sender = this.usersRepository.GetUserById(userId);
            var recipient = this.usersRepository.GetUserByPhoneNumber(input.RecipientPhoneNumber);

            var transaction = new Transaction
            {
                CreditAmount = input.CreditAmount,
                Message = input.Message,
                SenderId = sender.Id,
                RecipientId = recipient.Id,
                Date = DateTime.UtcNow.ToLocalTime()
            };

            sender.CreditAmount -= input.CreditAmount;
            recipient.CreditAmount += input.CreditAmount;
            
            this.transactionsRepository.CreateTransaction(transaction);
            this.transactionsRepository.SaveChanges();
        }

        public IEnumerable<TransactionViewModel> GetAll()
        {
            var transactions = this.transactionsRepository.GetAllTransactions()
                .Select(t => new TransactionViewModel
            {
                Date = t.Date,
                SenderName = t.Sender.UserName,
                RecipientName = t.Recipient.UserName,
                Message = t.Message,
                CreditAmount = t.CreditAmount,
            })
                .ToList();

            return transactions;
        }

        public IEnumerable<TransactionViewModel> ReceivedTransactions(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionViewModel> SentTransactions(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
