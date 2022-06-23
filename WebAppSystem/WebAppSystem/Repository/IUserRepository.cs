using WebAppSystem.Data.Models;

namespace WebAppSystem.Repository
{
    public interface IUserRepository
    {
        ApplicationUser GetUserByPhoneNumber(string phoneNumber);

        ApplicationUser GetUserById(string userId);

        IEnumerable<ApplicationUser> GetAllUsers();

        int GetCreditAmount(string userId);
    }
}
