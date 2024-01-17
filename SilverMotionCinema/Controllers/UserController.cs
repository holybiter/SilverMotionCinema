using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SilverMotionCinema.Data;

namespace SilverMotionCinema.Controllers
{
    public class UserController : Controller
    {
        private readonly SilverMotionContext _context;

        public UserController(SilverMotionContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registration(int? id, DateTime date)
        {
            return View();
        }
    }
}
