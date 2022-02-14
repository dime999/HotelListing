using HotelListing.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing
{
    public class AppDbContextcs  : DbContext
    {
        public AppDbContextcs(DbContextOptions options) : base (options)
        {

        }

        

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }







        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Bosnia", ShortName = "BiH" },
                  new Country { Id = 2, Name = "Turkey", ShortName = "Slo" },
                    new Country { Id = 3, Name = "Japan", ShortName = "Jp" }
                );

            builder.Entity<Hotel>().HasData(
               new Hotel { Id = 1, Name = "Bosnia", Adress = "Crkvice", CountryId = 1, Rating = 5 },
                 new Hotel { Id = 2, Name = "Turkey", Adress = "Istanbul", CountryId = 2, Rating = 4 },
                   new Hotel { Id = 3, Name = "Japan", Adress = "Islands", CountryId = 3, Rating = 3 }
               );
        }
    }
}
