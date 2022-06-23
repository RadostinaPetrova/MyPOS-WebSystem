using WebAppSystem.Models.Dashboard;
using WebAppSystem.Repository;

namespace WebAppSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository users;

        public UserService(IUserRepository users)
        {
            this.users = users;
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var users = this.users.GetAllUsers().
                Where(u => !u.Email.StartsWith("admin"))
                .Select(u => new UserViewModel
                {
                    Email = u.Email,
                    CreditAmount = u.CreditAmount,
                }).ToList();

            return users;
        }
    }
}
