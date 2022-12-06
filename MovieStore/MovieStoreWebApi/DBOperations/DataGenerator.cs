using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                context.Directors.AddRange(
          new Director { Name = "Chad", LastName = "Stahelski", FilmsDirected = "John Wick"},
          new Director { Name = "Duncan", LastName = "Jones", FilmsDirected = "Source Code"}
          );
                context.SaveChanges();

                context.Actors.AddRange(
                  new Actor { Name = "Keanu", LastName = "Reeves", PlayedMovies = "John Wick"},
                  new Actor { Name = "Chad", LastName = "Stahelski", PlayedMovies = "John Wick"},
                  new Actor { Name = "Bridget", LastName = "Moynahan", PlayedMovies = "John Wick"},
                  new Actor { Name = "lan", LastName = "McShane", PlayedMovies = "John Wick"},
                  new Actor { Name = "Jake", LastName = "Gyllenhaal", PlayedMovies = "Source Code"},
                  new Actor { Name = "Michelle", LastName = "Monaghan", PlayedMovies = "Source Code"}
                  );
                context.SaveChanges();

                context.Movies.AddRange(

                    new Movie
                    {
                        GenreID = 1,
                        Title = "John Wick",
                        Year = "2014",
                        Director = "Chad Stahelski",
                        Actors = "Keanu Reeves, Chad Stahelski, Bridget Moynahan, lan McShane ",
                        Price = 100

                    },

                    new Movie
                    {
                        GenreID = 2,
                        Title = "Source Code",
                        Year = "2011",
                        Director = "Duncan Jones",
                        Actors = " Jake Gyllenhaal, Michelle Monaghan",
                        Price = 85
                    }
                    );

                context.Genres.AddRange(
                   new Genre
                   {
                       Name = "Action "
                   },
                   new Genre
                   {
                       Name = "sciencefiction "
                   },
                   new Genre
                   {
                       Name = "Comedy"
                   }
               );
                context.SaveChanges();

                context.Customers.AddRange(
         new Customer
         {
             Name = "Onur",
             LastName = "Koca",
             Email = "onur@mail.com",
             Password = "123456"

         },
         new Customer
         {
             Name = "Mehmet",
             LastName = "Kozanoğlu",
             Email = "mehmet@mail.com",
             Password = "123456"

         },
         new Customer
         {
             Name = "Eren",
             LastName = "Bilgen",
             Email = "eren@mail.com",
             Password = "123456"

         });


                context.SaveChanges();

                context.Orders.AddRange(
                  new Order { CustomerId = 1 , MovieId = 1, purchasedTime = new DateTime(2022, 01, 01)},
                  new Order { CustomerId = 2 , MovieId = 1, purchasedTime = new DateTime(2022, 05, 08)},
                  new Order { CustomerId = 3 , MovieId = 2, purchasedTime = new DateTime(2022, 07, 15)}
                  );

                context.SaveChanges();

            }
        }

    }
}
