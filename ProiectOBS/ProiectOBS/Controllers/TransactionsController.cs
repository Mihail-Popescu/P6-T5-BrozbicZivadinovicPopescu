using Microsoft.AspNetCore.Mvc;

namespace ProiectOBS.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Transactions()
        {
            return View();
        }
    }
}
