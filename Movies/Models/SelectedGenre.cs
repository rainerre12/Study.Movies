namespace Movies.Models
{
    public class SelectedGenre
    {
        public int GenreId { get; set; }
        public List<GenreViewModel> genres { get; set; }
    }
}
