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
        private readonly IUserService usersService;
        private readonly IUserCreditAmountService userCreditAmountService;

        public TransactionsController(UserManager<ApplicationUser> userManager, ITransactionService transactionsService, IUserService usersService, IUserCreditAmountService userCreditAmountService)
        {
            this.userMaganer = userManager;
            this.transactionsService = transactionsService;
            this.usersService = usersService;
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
                var recipientId = this.usersService.GetUserId(input.RecipientPhoneNumber);

                if (userId == recipientId)
                {
                    this.ModelState.AddModelError(string.Empty, "You can't send credits to yourself.");
                    return View(input);
                }
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, "There is no registered user with this phone number.");
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

            return RedirectToAction("AuthorizedIndex", "Dashboard");
        }
    }
}
