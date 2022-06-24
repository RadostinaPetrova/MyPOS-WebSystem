namespace WebAppSystem.Repository
{
    using WebAppSystem.Data.Models;

    public interface IUserRepository
    {
        ApplicationUser GetUserByPhoneNumber(string phoneNumber);

        ApplicationUser GetUserById(string userId);

        IEnumerable<ApplicationUser> GetAllUsers();

        int GetCreditAmount(string userId);
    }
}
