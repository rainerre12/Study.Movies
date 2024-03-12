using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Movies.Context;
using Movies.Models;
using Movies.Models.CustomModel;
using System.Diagnostics;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel
            {
                GenreList = await GetAllGenres(),
                MoviesList = await GetAllAvailableMovies()
            };
            return View(model);

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
        public async Task<ActionResult> RegisterMovie(HomeViewModel model)
        {
            //Ignores these validation
            RemovalofModelState(AppModels.Operations.addmovie);

            if (ModelState.IsValid)
            {
                List<MoviesViewModel> validation = await GetAllAvailableMovies();
                validation = validation.Where(v => v.Name == model.Movies.Name).ToList();
                if(validation.Count > 0)
                {
                    model.ErrorMapping = 1; // Existing
                    model.selectedGenreId = model.selectedGenreId;
                    model.GenreList = await GetAllGenres();
                    return View("Index", model);
                }

                var NewMoview = new MoviesViewModel
                {
                    Name = model.Movies.Name,
                    Type = model.selectedGenreId,
                    IsAvailanble = true
                };

                _context.moviesViewModels.Add(NewMoview);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            model.selectedGenreId = -1;
            model.GenreList = await GetAllGenres();
            model.MoviesList = await GetAllAvailableMovies();
            return View("Index", model);
        }

        private async Task<List<GenreViewModel>> GetAllGenres()
        {
            try
            {
                return await _context.genreViewModels.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllGenresAsync: {ex.Message}");
                throw;
            }
        }

        private async Task<List<MoviesViewModel>> GetAllAvailableMovies()
        {
            try
            {
                return await _context.moviesViewModels.Where(m => m.IsAvailanble == true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllGenresAsync: {ex.Message}");
                throw;
            }
        }

        private void RemovalofModelState(int operation)
        {
            switch (operation)
            {
                case AppModels.Operations.addmovie:

                    ModelState.Remove("Movies.PersonMovieMaps");
                    ModelState.Remove("GenreList");
                    ModelState.Remove("MoviesList");
                    ModelState.Remove("Genre.Name");

                    break;
            }
        }
    }
}
