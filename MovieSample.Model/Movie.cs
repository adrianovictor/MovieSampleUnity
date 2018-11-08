using MovieSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieSample.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genres { get; set; }
        public DateTime Year { get; set; }
    }
}