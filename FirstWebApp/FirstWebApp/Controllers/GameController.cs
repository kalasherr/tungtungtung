using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstWebApp.Data;
using System.Diagnostics;

namespace FirstWebApp.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly DB _context;

        public GameController(ILogger<GameController> logger, DB context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }
        public IActionResult Index(int id)
        {
            var game = _context.Games.FirstOrDefault(g => g.id == id);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}