using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoConsole.Entities
{
    // Gives access to our App's Database
    // 1. Inherit from DbContext
    class ActorDbContext : DbContext
    {
        // 2. Create required DbSets
        // DbSet for Actors table
        public DbSet<Actor> Actors { get; set; }

        // 3. Configure
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            // specify connection string
            // Connect to the SQL Server with provided connection string
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ActorDb;Trusted_Connection=True;");
            // in real app put connection string into config file and read by using Configuration Manager

            /* Do a migration to create a database schema. 
                In your Package Manager Console:
                Add-Migration InitialMigration
               You can see your generated migrations in Migrations folder

               To run a migration type: Update-Database
            */
        }
    }
}

/*
     CREATE TABLE [Actors] (
        [Id] int NOT NULL IDENTITY,
        [AcademyWinner] bit NOT NULL,
        [Age] int NOT NULL,
        [Name] nvarchar(max),
        CONSTRAINT [PK_Actors] PRIMARY KEY ([Id])
    );
 */
