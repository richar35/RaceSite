using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RaceSite.Models;

namespace RaceSite.Models
{
    public class RaceContext : DbContext
    {
        public RaceContext(DbContextOptions<RaceContext> options)
             : base(options)
        {
        }

        public DbSet<Registrant> Registrant { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<Shoe> Shoe { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Registrant>().HasData(
                new Registrant { ID = 1, FirstName = "Adam", LastName = "Anderson", Age = 34, Address = "100 Willow St.", City = "Traverse City", State = "MI", Zip = "49696", Email = "runnerguy12@gmail.com", PhoneNumber = "(231)123-2222", RaceId = 1, ShoeId = 2 },
                new Registrant { ID = 2, FirstName = "Mary", LastName = "Hall", Age = 47, Address = "345 Park Ave.", City = "Clare", State = "MI", Zip = "49696", Email = "maryh@gmail.com", PhoneNumber = "(231)123-2345", RaceId = 1, ShoeId = 2 },
                new Registrant { ID = 3, FirstName = "Bob", LastName = "Wilson", Age = 63, Address = "5687 Pine St.", City = "Inaianapolis", State = "IN", Zip = "46298", Email = "bobtheman12@gmail.com", PhoneNumber = "(231)123-3456", RaceId = 1, ShoeId = 2 },
                new Registrant { ID = 4, FirstName = "Sam", LastName = "Richards", Age = 26, Address = "43 Bark Rd.", City = "Belleville", State = "AR", Zip = "72824", Email = "runnersam56@gmail.com", PhoneNumber = "(231)123-4567", RaceId = 1, ShoeId = 2 },
                new Registrant { ID = 5, FirstName = "Claire", LastName = "Rice", Age = 51, Address = "785 Washer Ln.", City = "Cocoa Beach", State = "FL", Zip = "32932", Email = "claire543@gmail.com", PhoneNumber = "(231)123-5678", RaceId = 1, ShoeId = 2 },
                new Registrant { ID = 6, FirstName = "Alex", LastName = "Berkley", Age = 19, Address = "41 Stark Rd.", City = "Jackson", State = "WY", Zip = "83002", Email = "alexb77@gmail.com", PhoneNumber = "(231)123-6789", RaceId = 1, ShoeId = 2 },
                new Registrant { ID = 7, FirstName = "Emma", LastName = "Rogers", Age = 37, Address = "634 Ridge Hwy", City = "Kalkaska", State = "MI", Zip = "49646", Email = "emmarunnergirl@gmail.com", PhoneNumber = "(231)123-7891", RaceId = 1, ShoeId = 2 },
                new Registrant { ID = 8, FirstName = "April", LastName = "Lane", Age = 49, Address = "790 Valley Rd", City = "Bude", State = "MS", Zip = "39630", Email = "lanea1@gmail.com", PhoneNumber = "(231)123-8912", RaceId = 1, ShoeId = 2 }


                );


            modelBuilder.Entity<Race>().HasData(
            new Race { ID = 1, RaceDate = new DateTime(2021, 05, 29), RaceName = "Bayshore Marathon Half Marathon & 10K", City = "Traverse City", State = "MI" },
            new Race { ID = 2, RaceDate = new DateTime(2021, 03, 15), RaceName = "Gazelle Girl Half Marathon 10K & 5K", City = "Grand Rapids", State = "MI" },
            new Race { ID = 3, RaceDate = new DateTime(2021, 11, 25), RaceName = "Turkey Legs Trifecta & Half Marathon", City = "Indianapolis", State = "IN" },
            new Race { ID = 4, RaceDate = new DateTime(2021, 02, 07), RaceName = "Space Coast Marathon", City = "Cocoa", State = "FL" },
            new Race { ID = 5, RaceDate = new DateTime(2021, 08, 12), RaceName = "Grand Teton Half Marathon", City = "Jackson", State = "WY" }
         );




            modelBuilder.Entity<Shoe>().HasData(
                new Shoe { ID = 1, Brand = "Brooks", Name = "Ghost 13", Use = "Road Running", Support = "Neutral" },
                new Shoe { ID = 2, Brand = "Hoka", Name = "Tennine", Use = "Trail Running", Support = "Stability" },
                new Shoe { ID = 3, Brand = "Saucany", Name = "Triumph 17 LE", Use = "Road Running", Support = "Neutral" },
                new Shoe { ID = 4, Brand = "Brooks", Name = "Glycerin", Use = "Road Running", Support = "Neutral" }

        );

       //     modelBuilder.Entity<RaceRegistrant>().HasData(
       //        new RaceRegistrant { ID = 1, RegistrantID = 1, RaceID = 1 },
       //      new RaceRegistrant { ID = 2, RegistrantID = 1, RaceID = 4 },
       //        new RaceRegistrant { ID = 3, RegistrantID = 2, RaceID = 4 },
       //        new RaceRegistrant { ID = 4, RegistrantID = 3, RaceID = 5 },
       //        new RaceRegistrant { ID = 2, RegistrantID = 3, RaceID = 1 },
       //        new RaceRegistrant { ID = 5, RegistrantID = 4, RaceID = 1 },
       //        new RaceRegistrant { ID = 6, RegistrantID = 5, RaceID = 2 },
       //        new RaceRegistrant { ID = 7, RegistrantID = 6, RaceID = 3 },
       //        new RaceRegistrant { ID = 8, RegistrantID = 6, RaceID = 1 },
       //        new RaceRegistrant { ID = 9, RegistrantID = 7, RaceID = 4 },
       //        new RaceRegistrant { ID = 10, RegistrantID = 8, RaceID = 2 }
       //);


        }

    }
}
