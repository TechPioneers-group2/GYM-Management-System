using GYM_Management_System.Data;
using GYM_Management_System.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Gym_System_test
{
    public class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly GymDbContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new GymDbContext(
                  new DbContextOptionsBuilder<GymDbContext>()
                  .UseSqlite(_connection).Options);

            _db.Database.EnsureCreated();
        }

        protected async Task<Supplement> CreateAndSaveSupplementTest()
        {
            var supplement = new Supplement()
            {
                Name = "Test",
                Price = "Test",
            };
            _db.Supplements.Add(supplement);
            await _db.SaveChangesAsync();

            Assert.NotEqual(0, supplement.SupplementID);
            return supplement;
        }
        protected async Task DeleteSupplementForTest(int supplementId)
        {
            var supplementToDelete = await _db.Supplements.FindAsync(supplementId);
            if (supplementToDelete != null)
            {
                _db.Supplements.Remove(supplementToDelete);
                await _db.SaveChangesAsync();
            }
        }

        protected async Task UpdateSupplementForTest(int supplementId, string newName, string newPrice)
        {
            var supplementToUpdate = await _db.Supplements.FindAsync(supplementId);
            if (supplementToUpdate != null)
            {
                supplementToUpdate.Name = newName;
                supplementToUpdate.Price = newPrice;
                _db.Entry(supplementToUpdate).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
        }
        protected async Task<GymEquipment> CreateAndSaveGymEquipmentTest()
        {
            var gymEquipment = new GymEquipment()
            {
                Name = "Test Equipment",
                Quantity = 10,
                OutOfService = 0,
                GymID = 1 // Change this to the appropriate GymID
            };

            _db.GymEquipments.Add(gymEquipment);
            await _db.SaveChangesAsync();

            Assert.NotEqual(0, gymEquipment.GymEquipmentID);
            return gymEquipment;
        }

        protected async Task DeleteGymEquipmentForTest(int gymEquipmentId)
        {
            var gymEquipmentToDelete = await _db.GymEquipments.FindAsync(gymEquipmentId);
            if (gymEquipmentToDelete != null)
            {
                _db.GymEquipments.Remove(gymEquipmentToDelete);
                await _db.SaveChangesAsync();
            }
        }

        protected async Task UpdateGymEquipmentForTest(int gymEquipmentId, int newQuantity, int newOutOfService)
        {
            var gymEquipmentToUpdate = await _db.GymEquipments.FindAsync(gymEquipmentId);
            if (gymEquipmentToUpdate != null)
            {
                gymEquipmentToUpdate.Quantity = newQuantity;
                gymEquipmentToUpdate.OutOfService = newOutOfService;
                _db.Entry(gymEquipmentToUpdate).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
        }



        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
    }
}