using System;
using System.Linq;
using gym_management_system_front_end.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gym_management_system_front_end.Models.Data
{
    public class GymDbContext : IdentityDbContext<ApplicationUser>
    {
        public GymDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GymSupplement>().HasKey(sq => new { sq.GymID, sq.SupplementID });

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

            modelBuilder.Entity<Gym>().HasData(
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
                    Price = "80 JD",
                    Description = "Whey protein is a mixture of proteins isolated from whey, which is the liquid part of milk that separates during cheese production.\r\nMilk actually contains two main types of protein: casein (80%) and whey (20%).",
                },
                new Supplement
                {
                    SupplementID = 2,
                    Name = "Creatine Monohydrate",
                    Price = "40 JD",
                    Description = "Creatine is a combination of three different amino acids: glycine, arginine, and methionine.",
                },
                new Supplement
                {
                    SupplementID = 3,
                    Name = "Branched-Chain Amino Acids (BCAAs)",
                    Price = "30 JD",
                    Description = "Branched-Chain Amino Acids (BCAAs) are a group of three essential amino acids: leucine, isoleucine, and valine. They are called branched-chain because they are the only three amino acids to have a chain that branches off to one side.",
                },
                new Supplement
                {
                    SupplementID = 4,
                    Name = "Pre-Workout Blend",
                    Price = "50 JD",
                    Description = "A pre-workout blend is a class of powdered drink mixes that are consumed 20-30 minutes prior to the beginning of a rigorous workout to increase exercise performance.",
                }
            );

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
                    Quantity = 10,
                    OutOfService = 2,
                },
                new GymEquipment
                {
                    GymID = 2,
                    GymEquipmentID = 4,
                    Name = "dumbbells",
                    Quantity = 60,
                    OutOfService = 0,
                },
                new GymEquipment
                {
                    GymID = 2,
                    GymEquipmentID = 5,
                    Name = "elliptical machine",
                    Quantity = 3,
                    OutOfService = 0,
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    UserId = "2",
                    EmployeeID = 1,
                    GymID = 1,
                    Name = "Employee",
                    JobDescription = "Demo",
                    IsAvailable = true,
                    WorkingDays = "S M T W T F S",
                    WorkingHours = "9AM - 5PM",
                    Salary = "$300"
                }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    UserId = "3",
                    ClientID = 1,
                    GymID = 1,
                    Name = "Client",
                    InGym = true,
                    SubscriptionTierID = 1,
                    SubscriptionDate = DateTime.Now,
                    SubscriptionExpiry = DateTime.Now.AddMonths(6),
                },
                new Client
                {
                    UserId = "4",
                    ClientID = 2,
                    GymID = 1,
                    Name = "Client2",
                    InGym = true,
                    SubscriptionTierID = 1,
                    SubscriptionDate = DateTime.Now,
                    SubscriptionExpiry = DateTime.Now.AddMonths(6),
                }
            );

            var hasher = new PasswordHasher<ApplicationUser>();
            var Admin = new ApplicationUser
            {
                Id = "1",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "adminUser@example.com",
                PhoneNumber = "1234567890",
                NormalizedEmail = "ADMINUSER@EXAMPLE.COM",
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            Admin.PasswordHash = hasher.HashPassword(Admin, "Admin@123");

            modelBuilder.Entity<ApplicationUser>().HasData(Admin);

            var Employee = new ApplicationUser
            {
                Id = "2",
                UserName = "Employee",
                NormalizedUserName = "EMPLOYEE",
                Email = "employeeUser@example.com",
                PhoneNumber = "1234567890",
                NormalizedEmail = "EMPLOYEEUSER@EXAMPLE.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
            };
            Employee.PasswordHash = hasher.HashPassword(Employee, "Employee@123");

            modelBuilder.Entity<ApplicationUser>().HasData(Employee);

            var Client = new ApplicationUser
            {
                Id = "3",
                UserName = "Client",
                NormalizedUserName = "CLIENT",
                Email = "ClientUser@example.com",
                PhoneNumber = "1234567890",
                NormalizedEmail = "CLIENTUSER@EXAMPLE.COM",
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            Client.PasswordHash = hasher.HashPassword(Client, "Client@123");

            modelBuilder.Entity<ApplicationUser>().HasData(Client);

            var Client2 = new ApplicationUser
            {
                Id = "4",
                UserName = "Client2",
                NormalizedUserName = "CLIENT2",
                Email = "Client2User@example.com",
                PhoneNumber = "1234567890",
                NormalizedEmail = "CLIENT2USER@EXAMPLE.COM",
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            Client2.PasswordHash = hasher.HashPassword(Client2, "Client2@123");

            modelBuilder.Entity<ApplicationUser>().HasData(Client2);

            SeedRole(modelBuilder, "Admin", "createAdmin", "updateAdmin", "deleteAdmin", "readAdmin");
            SeedRole(modelBuilder, "Employee", "createEmployee", "updateEmployee", "readEmployee");
            SeedRole(modelBuilder, "Client", "updateClient", "readClient");
        }

        int nextId = 1;
        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            modelBuilder.Entity<IdentityRole>().HasData(role);

            var roleClaim = permissions.Select(permission =>
                new IdentityRoleClaim<string>
                {
                    Id = nextId++,
                    RoleId = role.Id,
                    ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    ClaimValue = permission
                }
            ).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaim);
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
