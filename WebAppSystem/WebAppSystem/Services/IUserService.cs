namespace WebAppSystem.Services
{
    using WebAppSystem.Models.Dashboard;

    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUsers();

        string GetUserId(string phoneNumber);
    }
}
