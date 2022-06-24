namespace WebAppSystem.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using WebAppSystem.Data.Models;
    using WebAppSystem.Models;
    using WebAppSystem.Models.Dashboard;
    using WebAppSystem.Models.Transactions;
    using WebAppSystem.Services;

    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> userMaganer;
        private readonly ITransactionService transactionsService;
        private readonly IUserService usersService;

        public DashboardController(UserManager<ApplicationUser> userMaganer, ITransactionService transactionsService, IUserService usersService)
        {
            this.userMaganer = userMaganer;
            this.transactionsService = transactionsService;
            this.usersService = usersService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult AuthorizedIndex()
        {
                var userId = this.userMaganer.GetUserId(this.User);
                var userName = this.userMaganer.Users.First(u => u.Id == userId).UserName;

                var receivedTransactions = this.transactionsService.GetAll().Where(t => t.RecipientName == userName).ToList();
                var sendTransactions = this.transactionsService.GetAll().Where(t => t.SenderName == userName).ToList();

                var viewModel = new TransactionHistoryViewModel
                {
                    ReceivedTransactions = receivedTransactions,
                    SendTransactions = sendTransactions
                };

                return View(viewModel);
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