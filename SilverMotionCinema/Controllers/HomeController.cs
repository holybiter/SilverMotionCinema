using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SilverMotionCinema.Areas.Identity.Data;
using SilverMotionCinema.Data;
using SilverMotionCinema.Models;
using System.Diagnostics;

namespace SilverMotionCinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SilverMotionContext _context;
        private readonly UserManager<SilverMotionUser> _userManager;

        public HomeController(ILogger<HomeController> logger, SilverMotionContext context, UserManager<SilverMotionUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            List<Movie> movies = _context.Movies
            .Where(m => m.Selected == true)
            .Include(m => m.Genres)
            .Include(m => m.Language)
            .Include(m => m.AgeRatingNavigation)
            .ToList();
            return View(movies);
        }

        [Authorize(Roles = "Admin")]
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
