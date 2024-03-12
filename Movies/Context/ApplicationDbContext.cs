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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonMovieMaps>()
                .HasKey(pm => pm.Id);

            modelBuilder.Entity<PersonMovieMaps>()
                .HasOne(pm => pm.Person)
                .WithMany(p => p.PersonMovieMaps)
                .HasForeignKey(pmm => pmm.PersonID);

            modelBuilder.Entity<PersonMovieMaps>()
                .HasOne(pmm => pmm.Movie)
                .WithMany(m => m.PersonMovieMaps)
                .HasForeignKey(pmm => pmm.MovieID);


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<PersonsViewModel> personsViewModels { get; set; }
        public DbSet<MoviesViewModel> moviesViewModels { get; set; }
        public DbSet<GenreViewModel> genreViewModels { get; set; }
        public DbSet<PersonMovieMaps> PersonMovieMaps { get; set; }
    }
}


