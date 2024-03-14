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

        #region Index 

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel
            {
                GenreList = await GetAllGenres(),
                MoviesList = await GetAllAvailableMovies(),
                PersonsList = await GetAllPersons()

            };
            return View(model);

        }

        public IActionResult AddPersonClicked()
        {
            return PartialView("~/Views/Home/Dialog/_AddPersonModal.cshtml");
        }

        public async Task<IActionResult> AddMovieClicked()
        {
            var model = new HomeViewModel();
            model.GenreList = await GetAllGenres();
            return PartialView("~/Views/Home/Dialog/_AddMovieModal.cshtml", model);
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
                if (validation.Count > 0)
                {
                    model.ErrorMapping = 1; // Existing
                    model.selectedGenreId = model.selectedGenreId;
                    model.GenreList = await GetAllGenres();
                    model.MoviesList = await GetAllAvailableMovies();
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

        [HttpPost]
        public async Task<ActionResult> RegisterPerson(HomeViewModel model)
        {
            //Ignores these validation
            RemovalofModelState(AppModels.Operations.addperson);
            if (ModelState.IsValid)
            {
                var NewPerson = new PersonsViewModel
                {
                    FirstName = model.Persons.FirstName,
                    LastName = model.Persons.LastName,
                    IsActive = true
                };

                _context.personsViewModels.Add(NewPerson);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
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


        private async Task<List<PersonsViewModel>> GetAllPersons()
        {
            try
            {
                return await _context.personsViewModels.OrderBy(p => p.IsActive).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllGenresAsync: {ex.Message}");
                throw;
            }
        }


        private void RemovalofModelState(int operation)
        {
            var invalidFields = ModelState.Where(x => x.Value.Errors.Any())
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToList());
            switch (operation)
            {

                case AppModels.Operations.addmovie:

                    foreach (var entry in invalidFields)
                    {
                        string FieldName = entry.Key;
                        ModelState.Remove(FieldName);
                    }
                    break;
                case AppModels.Operations.addperson:

                    foreach (var entry in invalidFields)
                    {
                        string FieldName = entry.Key;
                        ModelState.Remove(FieldName);
                    }
                    break;
            }
        }

        #endregion

        #region Privacy 

        public IActionResult Privacy()
        {
            return View();
        }


        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
