namespace Movies.Models
{
    public class PersonMovieMaps
    {
        public int Id { get; set; }
        public int PersonID { get; set; }
        public int MovieID { get; set; }

        public PersonsViewModel Person { get; set; }
        public MoviesViewModel Movie { get; set; }
    }
}
