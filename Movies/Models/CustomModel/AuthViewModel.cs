using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.Context;

namespace Movies.Models.CustomModel
{
    public class AuthViewModel
    {
        public PersonsViewModel Persons;
        public MoviesViewModel Movies;
        public long Id;
        public AuthViewModel()
        {

        }

        //public string getAuthName()
        //{
        //    //this.Persons
        //    //return Persons.FirstName + " " + Persons.LastName;
        //    Movies = this.moviesViewModels.Where(m => m.Id == 4).FirstOrDefault();

        //    return Movies.Name;
        //}
    }
}
