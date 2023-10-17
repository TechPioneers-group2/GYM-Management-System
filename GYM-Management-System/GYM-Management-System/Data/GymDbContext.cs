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
                },
                new Supplement
                {
                    SupplementID = 5,
                    Name = "BCAA Energy Drink",
                    Price = "35 JD",
                    Description = "BCAA Energy Drink is a powerful blend of Branched-Chain Amino Acids (BCAAs), providing energy and supporting muscle recovery during workouts.",
                },
                new Supplement
                {
                    SupplementID = 6,
                    Name = "Pre-Workout Nitric Oxide Booster",
                    Price = "60 JD",
                    Description = "This Pre-Workout Nitric Oxide Booster is designed to enhance focus, increase energy levels, and improve blood flow for optimal workout performance.",
                },
                new Supplement
                {
                    SupplementID = 7,
                    Name = "Glutamine Capsules",
                    Price = "25 JD",
                    Description = "Glutamine Capsules provide essential amino acids that aid in muscle recovery, immune system support, and reducing muscle soreness after intense workouts.",
                },
                new Supplement
                {
                    SupplementID = 8,
                    Name = "Omega-3 Fish Oil",
                    Price = "45 JD",
                    Description = "Omega-3 Fish Oil supplements are rich in essential fatty acids that support cardiovascular health, joint function, and muscle recovery.",
                },
                new Supplement
                {
                    SupplementID = 9,
                    Name = "L-Carnitine Fat Burner",
                    Price = "55 JD",
                    Description = "L-Carnitine Fat Burner helps convert stored body fat into energy, making it an effective supplement for those looking to manage weight and increase endurance.",
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
                    PhotoUrl = "https://m.media-amazon.com/images/I/61cGWhpz3ZL._AC_UF1000,1000_QL80_.jpg",
                },
                new GymEquipment
                {
                    GymID = 1,
                    GymEquipmentID = 3,
                    Name = "treadmill",
                    Quantity = 10,
                    OutOfService = 2,
                    PhotoUrl = "https://shop.lifefitness.com/cdn/shop/products/clubseries-plus-treadmill-titanium-storm-se3hd-1000x1000_1800x1800.jpg?v=1678726811",
                },
                new GymEquipment
                {
                    GymID = 2,
                    GymEquipmentID = 4,
                    Name = "dumbbells",
                    Quantity = 60,
                    OutOfService = 0,
                    PhotoUrl = "https://www.bowflex.com/dw/image/v2/AAYW_PRD/on/demandware.static/-/Sites-nautilus-master-catalog/default/dwf21fb1cf/images/bfx/weights/100131/bowflex-selecttech-552-dumbbell-weights-hero.jpg?sw=2600&sh=1464&sm=fit",
                },
                new GymEquipment
                {
                    GymID = 2,
                    GymEquipmentID = 5,
                    Name = "elliptical machine",
                    Quantity = 3,
                    OutOfService = 0,
                    PhotoUrl = "https://www.precorhomefitness.com/cdn/shop/products/precor-efx-635-elliptical_5000x.jpg?v=1686422733",
                });


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
