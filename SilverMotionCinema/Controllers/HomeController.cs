using Microsoft.AspNetCore.Mvc;
using SilverMotionCinema.Data;
using SilverMotionCinema.Models;
using System.Diagnostics;

namespace SilverMotionCinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SilverMotionContext _context;

        public HomeController(ILogger<HomeController> logger, SilverMotionContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            var movies = _context.Movies.Where(m => m.Selected == true).ToList();
            return View(movies);
        }

        public IActionResult Privacy()
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
