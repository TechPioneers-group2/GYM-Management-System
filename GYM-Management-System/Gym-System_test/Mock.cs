using GYM_Management_System.Data;
using GYM_Management_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;

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