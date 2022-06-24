namespace WebAppSystem.Services
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using WebAppSystem.Data.Models;
    using WebAppSystem.Models.Transactions;
    using WebAppSystem.Repository;

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionsRepository;
        private readonly IUserRepository usersRepository;
        private readonly UserManager<ApplicationUser> userMaganer;

        public TransactionService(ITransactionRepository transactionsRepository, IUserRepository usersRepository, UserManager<ApplicationUser> userMaganer)
        {
            this.transactionsRepository = transactionsRepository;
            this.usersRepository = usersRepository;
            this.userMaganer = userMaganer;
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
                    Message = t.Message,
                    CreditAmount = t.CreditAmount,
                    SenderName = userMaganer.Users.First(u => u.Id == t.SenderId).UserName,
                    RecipientName = userMaganer.Users.First(u => u.Id == t.RecipientId).UserName
                })
                .ToList();

            return transactions;
        }
    }
}
