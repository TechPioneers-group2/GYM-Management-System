using GYM_Management_System.Data;
using GYM_Management_System.Models;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using GYM_Management_System.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.InteropServices;

namespace Gym_System_test
{
    public class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        public readonly GymDbContext _db;
        


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

        

        protected async Task<SubscriptionTier> CreateAndSaveSubscriptionTierTest()
        {
            var subscriptionTier = new SubscriptionTier()
            {
                Name = "Test Tier",
                Price = "Test",
                Length = 30,
            };
            _db.SubscriptionTiers.Add(subscriptionTier);
            await _db.SaveChangesAsync();

            Assert.NotEqual(0, subscriptionTier.SubscriptionTierID);
            return subscriptionTier;
        }

        protected async Task DeleteSubscriptionTierForTest(int subscriptionTierId)
        {
            var subscriptionTierToDelete = await _db.SubscriptionTiers.FindAsync(subscriptionTierId);
            if (subscriptionTierToDelete != null)
            {
                _db.SubscriptionTiers.Remove(subscriptionTierToDelete);
                await _db.SaveChangesAsync();
            }
        }

        protected async Task UpdateSubscriptionTierForTest(int subscriptionTierId, string newName, string newPrice, int newLength)
        {
            var subscriptionTierToUpdate = await _db.SubscriptionTiers.FindAsync(subscriptionTierId);
            if (subscriptionTierToUpdate != null)
            {
                subscriptionTierToUpdate.Name = newName;
                subscriptionTierToUpdate.Price = newPrice;
                subscriptionTierToUpdate.Length = newLength;
                _db.Entry(subscriptionTierToUpdate).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
        }
        //-------------
     
        protected async Task<Client> createClientAndSave()
        {


            var newClient1 = new Client()
            {
                UserId = "1",
                GymID = 1,
                Name = "test",
                ClientID = 1, 
                InGym=false,
                SubscriptionDate= DateTime.Now,
                SubscriptionExpiry= DateTime.Now.AddMonths(1),
                SubscriptionTierID=1,
               

            };

            _db.Clients.Add(newClient1);
            await _db.SaveChangesAsync() ;
            return newClient1;
        }

        //-----------
        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
    }
}