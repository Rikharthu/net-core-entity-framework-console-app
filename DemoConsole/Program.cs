using DemoConsole.Entities;
using System;

namespace DemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Seed the database (generate entries)
            using (var db = new ActorDbContext())
            {
                // Seed
                db.Actors.AddRange(
                    new Actor
                    {
                        Name = "Bruce Lee",
                        Age = 75,
                        AcademyWinner = false
                    },
                    new Actor
                    {
                        Name = "Madonna",
                        Age = 55,
                        AcademyWinner = true
                    });
                // Apply changes to the database
                int count = db.SaveChanges();

                // Fetch data & write it out
                Console.WriteLine($"{count} records added");
                foreach (var Actor in db.Actors)
                {
                    Console.WriteLine($"Id={Actor.Id}, Name={Actor.Name}, Age={Actor.Age}, " +
                        $"AcademWinner={Actor.AcademyWinner}");
                }
            }


            Console.ReadLine();
        }
    }
}