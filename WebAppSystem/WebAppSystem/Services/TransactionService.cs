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

        public ICollection<TransactionViewModel> ReceivedTransactions(string userId)
        {
            /* return this.transactionsRepository.GetAllTransactions().Where(t => t.RecipientId == userId)
                  .OrderByDescending(t => t.Date)
                  .Select(t => new TransactionViewModel
                  {
                      SenderName = t.Sender.UserName,
                      Message = t.Message,
                      CreditAmount = t.CreditAmount
                  })
                  .ToList();*/
            throw new NotImplementedException();
        }

        public ICollection<TransactionViewModel> SentTransactions(string userId)
        {
            /*return this.transactionsRepository.GetAllTransactions().Where(t => t.SenderId == userId)
                  .OrderByDescending(t => t.Date)
                  .Select(t => new TransactionViewModel
                  {
                      RecipientName = t.Recipient.UserName,
                      Message = t.Message,
                      CreditAmount = t.CreditAmount
                  })
                  .ToList();*/
            throw new NotImplementedException();
        }
    }
}
