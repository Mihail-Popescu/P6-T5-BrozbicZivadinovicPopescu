using Microsoft.AspNetCore.Mvc;
using ProiectOBS.Data;
using ProiectOBS.Models;

namespace ProiectOBS.Controllers
{
    public class CreateAccount : Controller
    {
        private readonly ProiectOBSDbContext _context;

        public CreateAccount(ProiectOBSDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client account)
        {
            if (ModelState.IsValid)
            {
                _context.Client.Add(account);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(account);
        }
    }
}