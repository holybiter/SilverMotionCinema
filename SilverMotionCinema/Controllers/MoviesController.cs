using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SilverMotionCinema.Data;
using SilverMotionCinema.Models;

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
            var movies = _context.Movies.ToList();
            foreach (Movie movie in movies)
            {
                Console.WriteLine(movie.Title);
            }
            Console.WriteLine(movies.Count);
            return View(movies);
        }

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("You must pass a product ID in the route, for example, /Movie/Details/21");
            }
            Movie? movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if(movie == null)
            {
                return NotFound($"MovieId {movie.MovieId} not found.");
            }
            return View(movie);
        }
    }
}
