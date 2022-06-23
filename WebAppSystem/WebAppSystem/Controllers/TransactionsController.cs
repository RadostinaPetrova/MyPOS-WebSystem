namespace WebAppSystem.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using WebAppSystem.Data.Models;
    using WebAppSystem.Models.Transactions;
    using WebAppSystem.Services;

    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly UserManager<ApplicationUser> userMaganer;
        private readonly ITransactionService transactionsService;
        private readonly IUserCreditAmountService userCreditAmountService;

        public TransactionsController(UserManager<ApplicationUser> userManager, ITransactionService transactionsService, IUserCreditAmountService userCreditAmountService)
        {
            this.userMaganer = userManager;
            this.transactionsService = transactionsService;
            this.userCreditAmountService = userCreditAmountService;
        }

        public IActionResult Add()
        {
            var viewModel = new TransactionInputModel();

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(TransactionInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            var userId = this.userMaganer.GetUserId(this.User);

            //var recipient = this.usersRepository.GetUserByPhoneNumber(input.RecipientPhoneNumber);

            if (input.CreditAmount <= 0)
            {
                this.ModelState.AddModelError(string.Empty, "You can't send 0 or negative amount of credits.");
                return View(input);
            }

            if (input.CreditAmount > userCreditAmountService.GetUserCredits(userId))
            {
                this.ModelState.AddModelError(string.Empty, "You can't send more credits than you have.");
                return View(input);
            }            

            try
            {
                this.transactionsService.CreateTransaction(input, userId);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
