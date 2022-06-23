using WebAppSystem.Repository;

namespace WebAppSystem.Services
{
    public class UserCreditAmountService : IUserCreditAmountService
    {
        private readonly IUserRepository usersRepository;

        public UserCreditAmountService(IUserRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public int GetUserCredits(string userId)
        {
            return this.usersRepository.GetCreditAmount(userId);
        }
    }
}
