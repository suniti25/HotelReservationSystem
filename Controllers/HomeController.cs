﻿using HotelReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelReservationSystem.Controllers
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
            var successMessage = TempData["ReseervationSuccessMessage"] as string;
            ViewBag.SuccessMessage = successMessage;
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}