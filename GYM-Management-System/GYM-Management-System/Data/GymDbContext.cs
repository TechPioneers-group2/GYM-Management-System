﻿using GYM_Management_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GYM_Management_System.Data
{
    public class GymDbContext : IdentityDbContext<ApplicationUser>
    {
        public GymDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GymSupplement>().HasKey(
                sq => new { sq.GymID, sq.SupplementID });

            modelBuilder.Entity<SubscriptionTier>().HasData
            (
              new SubscriptionTier
              {
                  SubscriptionTierID = 1,
                  Name = "1 month",
                  Price = "30 JD",
                  Length = 1
              },

              new SubscriptionTier
              {
                  SubscriptionTierID = 2,
                  Name = "3 months",
                  Price = "60 JD",
                  Length = 3
              },

              new SubscriptionTier
              {
                  SubscriptionTierID = 3,
                  Name = "6 months",
                  Price = "110 JD",
                  Length = 6
              },
              new SubscriptionTier
              {
                  SubscriptionTierID = 4,
                  Name = "12 months",
                  Price = "200 JD",
                  Length = 12
              }
            );

            modelBuilder.Entity<Gym>().HasData

              (
                  new Gym
                  {
                      GymID = 1,
                      Name = "WillPower - Amman",
                      ActiveHours = "5AM-12PM",
                      Address = "Amman - University Street - Building 25",
                      MaxCapacity = "125",
                      CurrentCapacity = 1,
                      Notification = "Everything ok"

                  },
                  new Gym
                  {
                      GymID = 2,
                      Name = "WillPower - Zarqa",
                      ActiveHours = "6AM-12PM",
                      Address = "Zarqa - 36th Street - Building 20",
                      MaxCapacity = "100",
                      CurrentCapacity = 1,
                      Notification = "Everything ok"

                  },
                  new Gym
                  {
                      GymID = 3,
                      Name = "WillPower - Irbid",
                      ActiveHours = "6AM-12PM",
                      Address = "Irbid - Yarmouk University Street - Building 30",
                      MaxCapacity = "150",
                      CurrentCapacity = 0,
                      Notification = "Under maintenance until 9-9-2023 AD"

                  }
                );




            modelBuilder.Entity<Supplement>().HasData(
                 new Supplement
                 {
                     SupplementID = 1,
                     Name = "Whey Protein Powder",
                     Price = "80 JD"
                 },
                 new Supplement
                 {
                     SupplementID = 2,
                     Name = "Creatine Monohydrate",
                     Price = "40 JD"
                 },
                 new Supplement
                 {
                     SupplementID = 3,
                     Name = "Branched-Chain Amino Acids (BCAAs)",
                     Price = "30 JD"
                 },
                 new Supplement
                 {
                     SupplementID = 4,
                     Name = "Pre-Workout Blend",
                     Price = "50 JD"
                 });

            modelBuilder.Entity<GymEquipment>().HasData(
                new GymEquipment
                {
                    GymID = 1,
                    GymEquipmentID = 2,
                    Name = "bench press",
                    Quantity = 2,
                    OutOfService = 0,
                    img="https://m.media-amazon.com/images/I/61cGWhpz3ZL._AC_UF1000,1000_QL80_.jpg", 
                },
                new GymEquipment
                {
                    GymID = 1,
                    GymEquipmentID = 3,
                    Name = "treadmill",
                    Quantity = 10,
                    OutOfService = 2,
                    img = "https://shop.lifefitness.com/cdn/shop/products/clubseries-plus-treadmill-titanium-storm-se3hd-1000x1000_1800x1800.jpg?v=1678726811",
                },
                new GymEquipment
                {
                    GymID = 2,
                    GymEquipmentID = 4,
                    Name = "dumbbells",
                    Quantity = 60,
                    OutOfService = 0,
                    img= "https://www.bowflex.com/dw/image/v2/AAYW_PRD/on/demandware.static/-/Sites-nautilus-master-catalog/default/dwf21fb1cf/images/bfx/weights/100131/bowflex-selecttech-552-dumbbell-weights-hero.jpg?sw=2600&sh=1464&sm=fit",
                },
                new GymEquipment
                {
                    GymID = 2,
                    GymEquipmentID = 5,
                    Name = "elliptical machine",
                    Quantity = 3,
                    OutOfService = 0,
                    img= "https://www.precorhomefitness.com/cdn/shop/products/precor-efx-635-elliptical_5000x.jpg?v=1686422733",
                });


            SeedRole(modelBuilder, "Admin", "createAdmin", "updateAdmin", "deleteAdmin", "readAdmin");
            SeedRole(modelBuilder, "Employee", "createEmployee", "updateEmployee", "readEmployee");
            SeedRole(modelBuilder, "Client", "updateClient", "readClient");

        }

        int nextId = 1;
        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            var roleClaim = permissions.Select(permissions =>
            new IdentityRoleClaim<string>
            {
                Id = nextId++,
                RoleId = role.Id,
                ClaimType = "permissions",
                ClaimValue = permissions
            }
            ).ToArray();

            modelBuilder.Entity<IdentityRole>().HasData(role);
        }

        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<GymEquipment> GymEquipments { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<GymSupplement> GymSupplements { get; set; }
        public DbSet<SubscriptionTier> SubscriptionTiers { get; set; }
    }
}
