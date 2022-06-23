namespace WebAppSystem.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebAppSystem.Services;
    using WebAppSystem.Models.Transactions;

    [Area("Administration")]
    public class DashboardController : AdministrationController
    {
        private readonly ITransactionService transactionsService;
        public DashboardController(ITransactionService transactionsService)
        {
            this.transactionsService = transactionsService;
        }

        public IActionResult Index()
        {
            var viewModel = new TransactionsListViewModel
            {
                Transactions = this.transactionsService.GetAll()
            };

            return this.View(viewModel);
        }

        public IActionResult AllUsers()
        {

            return this.View();
        }
    }
}
