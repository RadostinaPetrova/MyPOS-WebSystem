namespace WebAppSystem.Services
{
    using WebAppSystem.Models.Dashboard;
    using WebAppSystem.Repository;

    public class UserService : IUserService
    {
        private readonly IUserRepository usersRepository;

        public UserService(IUserRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var users = this.usersRepository.GetAllUsers().
                Where(u => !u.Email.StartsWith("admin"))
                .Select(u => new UserViewModel
                {
                    Email = u.Email,
                    CreditAmount = u.CreditAmount,
                }).ToList();

            return users;
        }

        public string GetUserId(string phoneNumber)
        {
            var userId = this.usersRepository.GetUserByPhoneNumber(phoneNumber).Id;

            return userId;
        }

    }
}
