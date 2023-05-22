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
            clientId = 1;
            var accountBalance = _transactionsService.GetAccountBalance(clientId);

            var Client = new Client { Id = clientId, Balance = accountBalance };

            return View("Transactions", Client);
        }

        [HttpPost]
        public IActionResult Deposit([FromForm] int clientId , [FromForm] int depositAmount)
        {
            clientId = 1;
            _transactionsService.AddDeposit(clientId, depositAmount);

            // Redirect back to the Transactions page or any other desired page
            return RedirectToAction("Transactions");
        }

        [HttpPost]
        public IActionResult Withdraw([FromForm] int clientId, [FromForm] string withdrawBank, [FromForm] int withdrawAmount)
        {
            clientId = 1;
            _transactionsService.AddWithdrawal(clientId, withdrawBank, withdrawAmount);

            // Redirect back to the Transactions page or any other desired page
            return RedirectToAction("Transactions");
        }

        [HttpPost]
        public IActionResult Transfer([FromForm] int clientId, [FromForm] int transferRecipient, [FromForm] int transferIBAN, [FromForm] int transferAmount)
        {
            clientId = 1;
            _transactionsService.AddTransfer(clientId, transferRecipient, transferIBAN, transferAmount);

            // Redirect back to the Transactions page or any other desired page
            return RedirectToAction("Transactions");
        }
    }
}