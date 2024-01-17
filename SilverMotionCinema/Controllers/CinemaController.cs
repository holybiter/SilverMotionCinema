using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SilverMotionCinema.Data;
using SilverMotionCinema.Models.ViewModels;

namespace SilverMotionCinema.Controllers
{
    public class CinemaController : Controller
    {
        private readonly SilverMotionContext _context;

        public CinemaController(SilverMotionContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string cinemaSearchInput)
        {
            var city = _context.Cities.SingleOrDefault(c => c.Name == cinemaSearchInput);
            if (city != null)
            {
                List<Cinema> cinemas = _context.Cinemas.Where(c => c.CityId == city.CityId).ToList();
                ViewBag.CityName = city.Name;
                ViewBag.CityState = city.State;
                ViewBag.Cinemas = cinemas;
                return View(ViewBag);
            }
            else
            {
                return View("Index");
            }
        }

        public IActionResult Details(int? id, DateTime date)
        {
            Console.WriteLine(date.ToString());
            if (!id.HasValue)
            {
                return BadRequest("You must pass a cinema ID in the route, for example, /Cinema/Details/21");
            }

            var selectedCinema = _context.Cinemas
                .Include(c => c.City)
                .Include(c => c.CinemaHalls)
                .FirstOrDefault(c => c.CinemaId == id);

            var cinemasInCity = _context.Cinemas
                .Where(c => c.City == selectedCinema.City)
                .ToList();

            var cinemaHalls = selectedCinema.CinemaHalls.ToList();

            var shows = _context.Shows
                .Where(s => s.CinemaHall.CinemaId == id && s.Date == date)
                .Include(s => s.Movie)
                .ThenInclude(s => s.Genres)
                .ToList();

            var movies = shows.Select(s => s.Movie)
                .GroupBy(m => m.Title, StringComparer.OrdinalIgnoreCase)
                .Select(g => g.First())
                .ToList();

            var viewModel = new CinemaDetailsViewModel
            {
                SelectedCinema = selectedCinema,
                CinemasInCity = cinemasInCity,
                CinemaHalls = cinemaHalls,
                Shows = shows,
                Movies = movies,
                SelectedDate = date
            };


            if (selectedCinema == null)
            {
                return NotFound($"CinemaId {selectedCinema.CinemaId} not found.");
            }

            return View(viewModel);
        }
    }
}
