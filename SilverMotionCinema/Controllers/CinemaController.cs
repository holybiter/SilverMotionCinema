using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SilverMotionCinema.Data;
using SilverMotionCinema.Models;

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

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("You must pass a cinema ID in the route, for example, /Cinema/Details/21");
            }
            Cinema? cinema = _context.Cinemas.FirstOrDefault(m => m.CinemaId == id);
            if (cinema == null)
            {
                return NotFound($"CinemaId {cinema.CinemaId} not found.");
            }
            return View(cinema);
        }
    }
}
