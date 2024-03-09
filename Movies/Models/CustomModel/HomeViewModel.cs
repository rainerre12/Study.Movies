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
        }

        public GenreViewModel Genre { get; set; }
        public MoviesViewModel Movies { get; set; }


        [Required(ErrorMessage = "Genre is required.")]
        public int selectedGenreId { get; set; } = 0;

        public List<GenreViewModel> GenreList { get; set; }


        public int ErrorMapping { get; set; }
    }
}
