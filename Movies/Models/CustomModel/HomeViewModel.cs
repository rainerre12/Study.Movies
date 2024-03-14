using Microsoft.AspNetCore.Mvc.Rendering;
using Movies.Context;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models.CustomModel
{
    public class HomeViewModel
    {

        public HomeViewModel()
        {
            Genre = new GenreViewModel();
            Movies = new MoviesViewModel();
            Persons = new PersonsViewModel();
        }

        public GenreViewModel Genre { get; set; }
        public MoviesViewModel Movies { get; set; }
        public PersonsViewModel Persons { get; set; }


        [Required(ErrorMessage = "Genre is required.")]
        public int selectedGenreId { get; set; } = 0;

        public List<GenreViewModel> GenreList { get; set; }
        public List<MoviesViewModel> MoviesList { get; set; }
        public List<PersonsViewModel> PersonsList { get; set; }

        public int ErrorMapping { get; set; }
    }
}
