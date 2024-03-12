﻿namespace Movies.Models
{
    public class PersonsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public ICollection<PersonMovieMaps> PersonMovieMaps { get; set; }
    }
}
