﻿using GYM_Management_System.Models;
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
            modelBuilder.Entity<Client>()
        .HasKey(c => new { c.GymID, c.ClientID });

            modelBuilder.Entity<SubscriptionTier>().HasData
                (
                  new SubscriptionTier
                  {
                      SubscriptionTierID = 1,
                      Name = "one month",
                      Price = "30 JD",
                      Length = 1
                  },

                  new SubscriptionTier
                  {
                      SubscriptionTierID = 2,
                      Name = "3 months",
                      Price = "50 JD",
                      Length = 3
                  },
              
                new SubscriptionTier
                {
                    SubscriptionTierID = 3,
                    Name = "6 months",
                    Price = "80 JD",
                    Length = 6
                }
                );

            modelBuilder.Entity<Gym>().HasData

              (
                  new Gym
                  {
                      GymID = 1,
                      Name = "WillPower-Amman",
                      ActiveHours = "5AM-12PM",
                      Address = "Amman",
                      MaxCapacity = "150",
                      CurrentCapacity = 0,
                      Notification = "Every thing ok"

                  },
                  new Gym
                  {
                      GymID = 2,
                      Name = "WillPower-Zarqa",
                      ActiveHours = "6AM-12PM",
                      Address = "Zarqa",
                      MaxCapacity = "120",
                      CurrentCapacity = 0,
                      Notification = "Every thing ok"

                  }
                );


            modelBuilder.Entity<Client>().HasData
                (new Client
                {
                    ClientID = 1,
                    GymID = 1,
                    SubscriptionTierID = 1,
                    Name = "Ahmad Harhoosh",
                    InGym = false,
                    SubscriptionDate = new DateTime(2023, 1, 1),
                    SubscriptionExpiry = new DateTime(2023, 4, 4),
                },

                new Client
                {
                    ClientID = 2,
                    GymID = 2,
                    SubscriptionTierID = 1,
                    Name = "Ammar Albisany",
                    InGym = false,
                    SubscriptionDate = new DateTime(2023, 1, 1),
                    SubscriptionExpiry = new DateTime(2023, 4, 4),
                }
                ); modelBuilder.Entity<Employee>().HasData
                (

                new Employee
                {
                   EmployeeID= 1,
                   Name="Ahmad",
                   Salary="500" ,
                   WorkingDays="sun-thu",
                   WorkingHours="2-10",
                   JobDescription="coach",
                   IsAvailable =false,
                   GymID=1 ,
                }
                ); modelBuilder.Entity<Employee>().HasData
                (

                new Employee
                {GymID=1,
                    EmployeeID = 2,
                    Name = "moh",
                    Salary = "500",
                    WorkingDays = "sun-thu",
                    WorkingHours = "2-10",
                    JobDescription = "trainer",
                    IsAvailable = false,
                }
                ); modelBuilder.Entity<GymEquipment>().HasData
                (

                new GymEquipment
                {
                   GymEquipmentID=1,
                   Name="tradmal",
                   Quantity=5 ,
                   OutOfService=0,
                   GymID=1,
                }
                ); modelBuilder.Entity<GymEquipment>().HasData
                (

                new GymEquipment
                {GymID=1,
                    GymEquipmentID = 2,
                    Name = "bench press",
                    Quantity = 2,
                    OutOfService = 0,
                }
                );

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 1,
                GymID = 1,
                Name = "Ahmad Albisany",
                JobDescription = "Trainer",
                IsAvailable = true,
                WorkingDays = "Sat - Fri",
                WorkingHours = "9:00AM - 5:00PM",
                Salary = "330 JD",
            });
            modelBuilder.Entity<Supplement>().HasData(
                new Supplement
                {
                    SupplementID = 1,
                    Name = "Whey Protein Powder",
                    Price = "80 JD"

                });



            modelBuilder.Entity<Client>()
                .Property(c => c.SubscriptionDate)
                .HasColumnType("date"); // Use the appropriate database type for DateOnly

            modelBuilder.Entity<Client>()
                        .Property(c => c.SubscriptionExpiry)
                        .HasColumnType("date");


            modelBuilder.Entity<GymSupplement>().HasKey(
                sq => new { sq.GymID, sq.SupplementID });

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
