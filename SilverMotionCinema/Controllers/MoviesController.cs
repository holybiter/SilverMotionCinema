using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SilverMotionCinema.Data;
using SilverMotionCinema.Models;
using System.Reflection.Metadata.Ecma335;

namespace SilverMotionCinema.Controllers
{
    public class MoviesController : Controller
    {
        private readonly SilverMotionContext _context;

        public MoviesController(SilverMotionContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Movie> movies = _context.Movies
            .Include(m => m.Genres)
            .Include(m => m.Language)
            .Include(m => m.AgeRatingNavigation)
            .ToList();
            return View(movies);
        }

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("You must pass a product ID in the route, for example, /Movie/Details/21");
            }
            var movie = _context.Movies
            .Where(m => m.MovieId == id)
            .Include(m => m.Genres)
            .Include(m => m.Language)
            .Include(m => m.AgeRatingNavigation)
            .SingleOrDefault();

            if (movie == null)
            {
                return NotFound($"MovieId {id} not found.");
            }
            return View(movie);
        }
    }
}
