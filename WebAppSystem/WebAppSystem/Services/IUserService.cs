using WebAppSystem.Models.Dashboard;

namespace WebAppSystem.Services
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUsers();
    }
}
