using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace FirstWebApp.Controllers
{


    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new Profile());
        }

        [HttpPost]
        public async Task<IActionResult> Login(Profile model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            if (model.Authenticated())
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username)
                };

                var identity = new ClaimsIdentity(claims, "Auth");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("Auth", principal);

                return RedirectToAction("Index");
                
            }

            return View(model);
            

        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var profile = new Profile();
            profile.fill_list();
            return View(profile.games);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Auth");
            return RedirectToAction("Login");
        }
        
    }
    
}