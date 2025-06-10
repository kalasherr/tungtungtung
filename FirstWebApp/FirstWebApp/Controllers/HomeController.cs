using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FirstWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string id)
        {
            ViewData["id"] = id;            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TopList(string tag)
        {
            return View();
        }

        public IActionResult Contacts()
        {
            ViewData["tel"] = 12345;
            ViewBag.email = "admin@mail.ru";

            return View();
        }
        
        public IActionResult About()
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
