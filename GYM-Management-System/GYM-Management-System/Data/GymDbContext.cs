using GYM_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace GYM_Management_System.Data
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubscriptionTier>().HasData
                (
                  new SubscriptionTier
                  {
                      SubscriptionTierID = 1,
                    Name = "1 month",
                      Price = "30 JD",
                      Length = new DateTime(2023, 3, 1)
                  },
                  new SubscriptionTier
                  {
                      SubscriptionTierID = 2,
                      Name = "3 months",
                      Price = "60 JD",
                      Length = new DateTime(2023, 3, 1)
                  },

                  new SubscriptionTier
                  {
                      SubscriptionTierID = 3,
                      Name = "6 months",
                      Price = "110 JD",
                      Length = new DateTime(2023, 3, 1)
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
                );


            modelBuilder.Entity<Client>()
                .Property(c => c.SubscriptionDate)
                .HasColumnType("date"); // Use the appropriate database type for DateOnly

            modelBuilder.Entity<Client>()
                .Property(c => c.SubscriptionExpiry)
                .HasColumnType("date");

            modelBuilder.Entity<SubscriptionTier>()
               .Property(c => c.Length)
               .HasColumnType("date");


            modelBuilder.Entity<GymSupplement>().HasKey(sq => new { sq.GymID, sq.SupplementID });
        }

        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<GymEquipment> GymEquipments { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<GymSupplement>GymSupplements { get; set; }
        public DbSet<SubscriptionTier> SubscriptionTiers { get; set; }
    }
}
