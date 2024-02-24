//using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;
using System;

namespace RazorPageMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPageMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPageMovieContext>>()))
            {
                if(context == null || context.Movie == null)  
                { 
                    throw new ArgumentException("Null RazorPagesMoviecontext"); 
                } 
                //Para mirar cualquier pelicula 
                if(context.Movie.Any())
                {
                    return; //Db muestra todo lo que contiene la clase
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        price = 7.99M, //millions
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        price = 8.99M, 
                        Rating = "G"
                    },
                    new Movie
                    {
                        Title = "Ghostbusters2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        price = 9.99M, 
                        Rating = "G"
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        price = 3.99M,
                        Rating = "NA"
                    }
                    ); 
                context.SaveChanges();
            }
        }
    }
}
