namespace WebAppSystem.Repository
{
    using WebAppSystem.Data;
    using WebAppSystem.Data.Models;

    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return this.dbContext.Users.ToList();
        }

        public int GetCreditAmount(string userId)
        {
            return this.dbContext.Users.Find(userId).CreditAmount;
        }

        public ApplicationUser GetUserById(string userId)
        {
            return this.dbContext.Users.Find(userId); ;
        }

        public ApplicationUser GetUserByPhoneNumber(string phoneNumber)
        {
            return this.dbContext.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
        }
    }
}
