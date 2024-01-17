using Microsoft.AspNetCore.Mvc;

namespace SilverMotionCinema.Controllers
{
    public class Admin : Controller
    {
        [BindProperty]
        public Movie? Movie { get; set; }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMovie()
        {

            return View();
        }
    }
}
