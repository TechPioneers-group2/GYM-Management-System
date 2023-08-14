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
            modelBuilder.Entity<Client>()
                .Property(c => c.SubscriptionDate)
                .HasColumnType("date"); // Use the appropriate database type for DateOnly

            modelBuilder.Entity<Client>()
                .Property(c => c.SubscriptionExpiry)
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
