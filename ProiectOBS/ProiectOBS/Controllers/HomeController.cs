﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProiectOBS.Models;

namespace ProiectOBS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AccountSettings()
        {
            return View();
        }
        public IActionResult AdminLogIn()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }
        public IActionResult Transactions()
        {
            return View();
        }

        public IActionResult Help()
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