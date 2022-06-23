namespace WebAppSystem.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebAppSystem.Services;
    using WebAppSystem.Models.Transactions;

    [Area("Administration")]
    public class DashboardController : AdministrationController
    {
        private readonly ITransactionService transactionsService;
        private readonly IUserService usersService;
        public DashboardController(ITransactionService transactionsService, IUserService usersService)
        {
            this.transactionsService = transactionsService;
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            var viewModel = this.transactionsService.GetAll();

            return this.View(viewModel);
        }

        public IActionResult AllUsers()
        {
            var viewModel = this.usersService.GetAllUsers();

            return this.View(viewModel);
        }
    }
}
