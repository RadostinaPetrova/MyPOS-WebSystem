using Microsoft.AspNetCore.Mvc;
using WebAppSystem.Services;

namespace WebAppSystem.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class DashboardController : AdministrationController
    {
        private readonly ITransactionService transactions;
        public DashboardController(ITransactionService transactions)
        {
            this.transactions = transactions;
        }

        public IActionResult Index()
        {
            var transactions = this.transactions.AllTransactions();

            return View(transactions);
        }
    }
}
