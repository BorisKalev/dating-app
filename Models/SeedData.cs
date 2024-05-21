using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjFinRBEM.Data;
using System;
using System.Linq;


namespace ProjFinRBEM.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjFinRBEMContext(
           serviceProvider.GetRequiredService<
               DbContextOptions<ProjFinRBEMContext>>()))
            {
                // Look for any movies.
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }
                context.User.AddRange(
                    new User
                    {
                        TypeOfUser = "Admin",
                        FirstName = "Bobby",
                        Username = "BobbyLee99",
                        Email = "bobbyLee9988@gmail.com",
                        DateOfBirth = DateTime.Parse("1984-3-13"),
                        Gender = "Male",
                        Password = "hotdog99"
                    },
                    new User
                    {
                        TypeOfUser = "MembreR",
                        FirstName = "Johnny",
                        Username = "JohnnyLee99",
                        Email = "JohnnyLee9988@gmail.com",
                        DateOfBirth = DateTime.Parse("1994-3-13"),
                        Gender = "Male",
                        Password = "bobo99"
                    },
                    new User
                    {
                        TypeOfUser = "MembreP",
                        FirstName = "Stacy",
                        Username = "StacyLee99",
                        Email = "stacyyLee9678@gmail.com",
                        DateOfBirth = DateTime.Parse("1984-3-13"),
                        Gender = "Female",
                        Password = "momo99"
                    },
                    new User
                    {
                        TypeOfUser = "MembreP",
                        FirstName = "Marcus",
                        Username = "MarcusLee99",
                        Email = "MarcusLee9678@gmail.com",
                        DateOfBirth = DateTime.Parse("1984-3-13"),
                        Gender = "Male",
                        Password = "popo66"
                    },
                    new User
                    {
                        TypeOfUser = "Invite",
                        FirstName = "Robby",
                        Username = "RobbyLee99",
                        Email = "RobbyLee9988@gmail.com",
                        DateOfBirth = DateTime.Parse("1990-3-13"),
                        Gender = "Male",
                        Password = "hothotdog99"
                    }
                );
                context.SaveChanges();





            }


        }

    }

}
