using Microsoft.AspNetCore.Mvc;
using ProiectOBS.Models;
using ProiectOBS.Services;

namespace ProiectOBS.Controllers
{
    public class CreateAccountController : Controller
    {

        private readonly CreateAccountService _createAccountService;

        public CreateAccountController(CreateAccountService createAccountService)
        {
            _createAccountService = createAccountService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client client, Address address, Card card)
        {
            if (ModelState.IsValid)
            {
                var result = await _createAccountService.CreateAccountAsync(client, address, card);
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the account");
                }
            }

            return View(client);
        }


        public IActionResult CreateAccount()
        {
            return View();
        }
    }
}