using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = _context.Leagues
                .Where(w => w.Name.Contains("Womens'"));
            ViewBag.Hockey = _context.Leagues
                .Where(h => h.Sport.Contains("Hockey"));
            ViewBag.NotFootball = _context.Leagues
                .Where(n => !n.Sport.Contains("Football"));
            ViewBag.Conferences = _context.Leagues
                .Where(c => c.Name.Contains("Conference"));
            ViewBag.Atlantic = _context.Leagues
                .Where(a => a.Name.Contains("Atlantic"));
            ViewBag.Dallas = _context.Teams
                .Where(d => d.Location.Contains("Dallas"));
            ViewBag.Raptors = _context.Teams
                .Where(r => r.TeamName.Contains("Raptors"));
            ViewBag.City = _context.Teams
                .Where(c => c.Location.Contains("City"));
            ViewBag.LetterT = _context.Teams
                .Where(l => l.TeamName.StartsWith("T"));
            ViewBag.Alphabetical = _context.Teams
                .OrderBy(a => a.Location);
            ViewBag.ReverseAlphabetical = _context.Teams
                .OrderByDescending(r => r.TeamName);
            ViewBag.Cooper = _context.Players
                .Where(c => c.LastName.Contains("Cooper"));
            ViewBag.Joshua = _context.Players
                .Where(j => j.FirstName.Contains("Joshua"))
                .OrderBy(j => j.LastName);
            ViewBag.CoopNotJosh = _context.Players
                .Where(c => c.LastName.Contains("Cooper"))
                .Where(c => !c.FirstName.Contains("Joshua"))
                .OrderBy(c => c.FirstName);
            ViewBag.AlexOrWyatt = _context.Players
                .Where(a => a.FirstName == "Alexander" || a.FirstName == "Wyatt");

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}