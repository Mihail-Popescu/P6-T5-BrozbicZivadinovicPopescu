using Microsoft.AspNetCore.Mvc;
using ProiectOBS.Models;
using ProiectOBS.Services;

namespace ProiectOBS.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly TransactionsService _transactionsService;

        public TransactionsController(TransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }
        public IActionResult Transactions(int clientId)
        {
            var accountBalance = _transactionsService.GetAccountBalance(clientId);

            var Client = new Client { Id = clientId, Balance = accountBalance };

            return View("Transactions", Client);
        }

        [HttpPost]
        public IActionResult Deposit([FromForm] int clientId, [FromForm] int amount)
        {
            _transactionsService.AddDeposit(clientId, amount);

            // Redirect back to the Transactions page or any other desired page
            return RedirectToAction("Index", new { clientId });
        }

        [HttpPost]
        public IActionResult Withdraw([FromForm] int clientId, [FromForm] string bank, [FromForm] int amount)
        {
            _transactionsService.AddWithdrawal(clientId, bank, amount);

            // Redirect back to the Transactions page or any other desired page
            return RedirectToAction("Index", new { clientId });
        }

        [HttpPost]
        public IActionResult Transfer([FromForm] int clientId, [FromForm] int recipient, [FromForm] int iban, [FromForm] int amount)
        {
            _transactionsService.AddTransfer(clientId, recipient, iban, amount);

            // Redirect back to the Transactions page or any other desired page
            return RedirectToAction("Index", new { clientId });
        }
    }
}