using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class MoviesViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required.")]
        public string Name { get; set; }
        public int Type { get; set; }
        public bool IsAvailanble { get; set; }
    }
}
