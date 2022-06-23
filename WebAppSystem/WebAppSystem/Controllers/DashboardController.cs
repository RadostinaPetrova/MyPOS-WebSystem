namespace WebAppSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using WebAppSystem.Models;
    using WebAppSystem.Models.Dashboard;

    public class DashboardController : Controller
    {
        public DashboardController()
        {

        }
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
            };
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