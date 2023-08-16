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
                      Name = "3 months",
                      Price = "30 JD",
                      Length = new DateTime(2023, 3, 1)
                  },

                  new SubscriptionTier
                  {
                      SubscriptionTierID = 2,
                      Name = "6 months",
                      Price = "150 JD",
                      Length = new DateTime(2023, 3, 1)
                  }
                );

            modelBuilder.Entity<Gym>().HasData

              (
                  new Gym
                  {
                      GymID = 1,
                      Name = "GYM1",
                      ActiveHours = "5AM-9PM",
                      Address = "Amman",
                      MaxCapacity = "150",
                      CurrentCapacity = 0,
                      Notification="Every thing ok"

                  },
                  new Gym
                  {
                      GymID = 2,
                      Name = "GYM1",
                      ActiveHours = "5AM-9PM",
                      Address = "Zarqa",
                      MaxCapacity = "150",
                      CurrentCapacity = 0,
                      Notification = "Every thing ok"

                  }
                ) ;


            modelBuilder.Entity<Client>().HasData
                (

                new Client
                {
                    ClientID = 1,
                    GymID=1,
                    SubscriptionTierID=1,
                    Name="ammar",
                    InGym=false,
                    SubscriptionDate=new DateTime(2023,1,1),
                    SubscriptionExpiry= new DateTime(2023,4,4),
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
        }

        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<GymEquipment> GymEquipments { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<SubscriptionTier> SubscriptionTiers { get; set; }
    }
}
