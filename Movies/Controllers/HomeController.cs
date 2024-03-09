using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movies.Context;
using Movies.Models;
using System.Diagnostics;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<GenreViewModel> genres = _context.genreViewModels.ToList();
            SelectList genreSelectList = new SelectList(genres, "Id", "Name");

            ViewBag.GenreSelectList = genreSelectList;
            var tuple = new Tuple<MoviesViewModel, GenreViewModel>(new MoviesViewModel(), new GenreViewModel());

            return View(tuple);
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



        [HttpPost]
        public ActionResult RegisterMovie(MoviesViewModel model, int selectedGenreId)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View("Index",model);
        }


    }
}
