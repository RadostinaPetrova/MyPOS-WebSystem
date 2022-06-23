namespace WebAppSystem.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using WebAppSystem.Data.Models;
    using WebAppSystem.Models;
    using WebAppSystem.Models.Dashboard;
    using WebAppSystem.Services;

    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> userMaganer;
        private readonly ITransactionService transactionsService;

        public DashboardController(UserManager<ApplicationUser> userMaganer, ITransactionService transactionsService)
        {
            this.userMaganer = userMaganer;
            this.transactionsService = transactionsService;
        }
        public IActionResult Index()
        {
            var userId = this.userMaganer.GetUserId(this.User);

            /*var receivedTransactions = this.transactionsService.ReceivedTransactions(userId);

            var viewModel = new TransactionHistoryViewModel
            {
                ReceivedTransactions = receivedTransactions,
            };

            return View(viewModel);*/
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}