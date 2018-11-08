using MovieSample.Persistency.Mappings;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using MovieSample.Model;

namespace MovieSample.Persistency.DataContext
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MovieContext : DbContext, IMovieContext
    {
        public MovieContext()
            : base("name=default")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(255));

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        protected virtual void OnCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GenreMap());
            modelBuilder.Configurations.Add(new MovieMap());
        }
    }

    public interface IMovieContext : IDisposable
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Genre> Genres { get; set; }

        int SaveChanges();
    }

    public interface IMovieService
    {
        Movie GetMovie(string title);
    }

    public class MovieService : IMovieService
    {
        private IMovieContext db;

        public MovieService(IMovieContext db)
        {
            this.db = db;
        }

        public Movie GetMovie(string title)
        {
            var query = db.Movies
                .Where(m => m.Title == title);

            var movie = query.FirstOrDefault();

            return movie;
        }
    }

    public static class MovieServiceExtensions
    {
        //public static IQueryable<Movie> GetMovieForYear(this IQueryable<Movie> movies, DateTime date)
        //{

        //}
    }
}