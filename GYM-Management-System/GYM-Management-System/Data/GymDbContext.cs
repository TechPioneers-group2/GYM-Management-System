using GYM_Management_System.Models;
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
                      Notification = "Everything ok"

                  }
                );


            //modelBuilder.Entity<Client>().HasData
            //    (new Client
            //    {
            //        ClientID = 1,
            //        GymID = 2,
            //        SubscriptionTierID = 1,
            //        Name = "Ahmad Harhoosh",
            //        InGym = true,
            //        SubscriptionDate = new DateTime(2023, 1, 1),
            //        SubscriptionExpiry = new DateTime(2023, 2, 1),
            //    },

            //    new Client
            //    {
            //        ClientID = 2,
            //        GymID = 1,
            //        SubscriptionTierID = 2,
            //        Name = "Ammar Albesani",
            //        InGym = true,
            //        SubscriptionDate = new DateTime(2023, 1, 1),
            //        SubscriptionExpiry = new DateTime(2023, 4, 4),
            //    },

            //    new Client
            //    {
            //        ClientID = 3,
            //        GymID = 3,
            //        SubscriptionTierID = 3,
            //        Name = "Ala' Abusalem",
            //        InGym = false,
            //        SubscriptionDate = new DateTime(2023, 1, 1),
            //        SubscriptionExpiry = new DateTime(2023, 6, 1),
            //    }
            //    );

            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee
            //    {
            //        EmployeeID = 1,
            //        GymID = 1,
            //        Name = "Nadine Almasri",
            //        JobDescription = "Dietitian",
            //        IsAvailable = true,
            //        WorkingDays = "Saturday - Friday",
            //        WorkingHours = "9:00AM - 5:00PM",
            //        Salary = "370 JD",
            //    }, new Employee
            //    {
            //        EmployeeID = 2,
            //        GymID = 2,
            //        Name = "Al-Hareth Alhyari",
            //        JobDescription = "Trainer",
            //        IsAvailable = true,
            //        WorkingDays = "Saturday - Thursday",
            //        WorkingHours = "9:00AM - 5:00PM",
            //        Salary = "400 JD",
            //    }, new Employee
            //    {
            //        EmployeeID = 3,
            //        GymID = 3,
            //        Name = "Bashar Owainat",
            //        JobDescription = "Trainer",
            //        IsAvailable = true,
            //        WorkingDays = "Monday - Friday",
            //        WorkingHours = "4:00PM - 12:00AM",
            //        Salary = "430 JD",
            //    });

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
                },
                new GymEquipment
                {
                    GymID = 1,
                    GymEquipmentID = 3,
                    Name = "treadmill",
                    Quantity = 5,
                    OutOfService = 1,
                },
                new GymEquipment
                {
                    GymID = 2,
                    GymEquipmentID = 4,
                    Name = "dumbbells",
                    Quantity = 10,
                    OutOfService = 0,
                },
                new GymEquipment
                {
                    GymID = 2,
                    GymEquipmentID = 5,
                    Name = "elliptical machine",
                    Quantity = 3,
                    OutOfService = 0,
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
