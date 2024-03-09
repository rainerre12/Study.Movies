using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<PersonsViewModel> personsViewModels { get; set; }
        public DbSet<MoviesViewModel> moviesViewModels { get; set; }
        public DbSet<GenreViewModel> genreViewModels { get; set; }
        public DbSet<PersonMovieMaps> PersonMovieMaps { get; set; }
    }
}
