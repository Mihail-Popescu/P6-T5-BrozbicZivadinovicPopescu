using Microsoft.AspNetCore.Mvc;

namespace ProiectOBS.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Help()
        {
            return View();
        }
    }
}
