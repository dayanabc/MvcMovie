using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;



namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "The RM",
                         ReleaseDate = DateTime.Parse("2003-1-31"),
                         Genre = "Religious",
                         Rating = "G",
                         Price = 7.99M
                     },

                     new Movie
                     {
                         Title = "Other Side of Heaven",
                         ReleaseDate = DateTime.Parse("2002-4-12"),
                         Genre = "Religious",
                         Rating = "G",
                         Price = 8.99M
                     },

                     new Movie
                     {
                         Title = "Meet the Mormons",
                         ReleaseDate = DateTime.Parse("2014-10-10"),
                         Genre = "Religious",
                         Rating = "G",
                         Price = 9.99M
                     }
                );
                context.SaveChanges();
            }
        }
    }
}

    