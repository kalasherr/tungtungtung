using System.Diagnostics;
using IdentityApp25.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp25.Controllers
{
 //
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(Request.Query.Keys.Contains("mytheme"))
            {
                var t = Request.Query["mytheme"].ToString();
                ViewData["theme"] = t;
                Response.Cookies.Append("theme", t);
            }

            if (Request.Cookies.Keys.Contains("theme"))
            {
                ViewData["theme2"] = Request.Cookies["theme"]?.ToString();                
            }

            if (Request.Query.Keys.Contains("name"))
            {
                var n = Request.Query["name"].ToString();
                ViewData["name"] = n;
                HttpContext.Session.SetString("name", n);
            }






            return View();
        }

        //[Authorize]
        public IActionResult Privacy()
        {

            if (HttpContext.Session.Keys.Contains("name"))
            {
                ViewData["name"] = HttpContext.Session.GetString("name");
                
            }

            return View();
        }

        [Authorize]
        public IActionResult Secret()
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
