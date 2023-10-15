using GYM_Management_System.Controllers;
using GYM_Management_System.Data;
using GYM_Management_System.Models;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using GYM_Management_System.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Moq;
using System;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace Gym_System_test
{
    public class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        public readonly GymDbContext _db;
        protected readonly jwtTokenServices _JwtTokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        protected readonly IUser _user;
        protected readonly ISubscriptionTier _tier;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new GymDbContext(
            new DbContextOptionsBuilder<GymDbContext>()
            .UseSqlite(_connection).Options);

            _db.Database.EnsureCreated();

            _user = new IdentityUserService(_db, _userManager, _JwtTokenService, _tier);

        }

        protected async Task CreateAndSaveEmplyee()
        {

            var Employee1 = new Employee()
            {
                UserId = "1",
                GymID = 1,
                Name = "test1",
                JobDescription = "Instructor",
                IsAvailable = true,
                WorkingDays = "test1",
                WorkingHours = "test1",
                Salary = "test1"
            };
            await _db.Employees.AddAsync(Employee1);
            await _db.SaveChangesAsync();


            var Employee2 = new Employee()
            {
                UserId = "2",
                GymID = 1,
                Name = "test2",
                JobDescription = "Instructor",
                IsAvailable = false,
                WorkingDays = "test2",
                WorkingHours = "test2",
                Salary = "test2"
            };
            await _db.Employees.AddAsync(Employee2);
            await _db.SaveChangesAsync();
            List<Employee> employees = new List<Employee>();
            employees.Add(Employee1);
            employees.Add(Employee2);
            //return employees;

        }
        protected async Task<Supplement> CreateAndSaveSupplementTest()
        {
            var supplement = new Supplement()
            {
                Name = "Test",
                Price = "Test",
                Description = "Test",
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

        protected async Task UpdateSupplementForTest(int supplementId, string newName, string newPrice, string newDescription)
        {
            var supplementToUpdate = await _db.Supplements.FindAsync(supplementId);
            if (supplementToUpdate != null)
            {
                supplementToUpdate.Name = newName;
                supplementToUpdate.Price = newPrice;
                supplementToUpdate.Description = newDescription;
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
                InGym = false,
                SubscriptionDate = DateTime.Now,
                SubscriptionExpiry = DateTime.Now.AddMonths(1),
                SubscriptionTierID = 1,


            };

            _db.Clients.Add(newClient1);
            await _db.SaveChangesAsync();
            return newClient1;
        }

        //-----------

        protected async Task<Gym> TestCreateGym()
        {
            var gym = new Gym()
            {
                Name = "Test",
                Address = "Amman",
                CurrentCapacity = 0,
                MaxCapacity = "100",
                ActiveHours = "2-5",
                Notification = "none"


            };
            _db.Gyms.Add(gym);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, gym.GymID);
            return gym;

        }
        protected async Task<GymSupplement> CreateNewGymSupplement()
        {
            var supplement = new GymSupplement()
            {
                SupplementID = 1,
                GymID = 1,
                Quantity = 50,
            };
            _db.GymSupplements.Add(supplement);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, supplement.SupplementID);
            return supplement;
        }
        protected async Task<GymSupplement> UpdateGymSupplement()
        {
            var supplement = new GymSupplement()
            {
                SupplementID = 1,
                GymID = 4,
                Quantity = 50,
            };
            _db.GymSupplements.Add(supplement);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, supplement.SupplementID);
            return supplement;
        }

        protected static IUser SetupUserMock(UserDTO expected)
        {
            var userMock = new Mock<IUser>();

            userMock.Setup(u => u.LogIn(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(expected);

            return userMock.Object;
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
    }
}
