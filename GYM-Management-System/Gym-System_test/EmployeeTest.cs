using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM_Management_System.Models;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using GYM_Management_System.Models.Services;
using Microsoft.IdentityModel.Tokens;

namespace Gym_System_test
{
	public class EmployeeTest : Mock
	{
		[Fact]
		public async Task testgetAllEmployees()
		{
			// Arrange
			await CreateAndSaveEmplyee();
			var employeeService = new EmployeeService(_db);


			// Act
			var Employees = await employeeService.GetEmployees();
			// Assert

			Assert.Equal(2, Employees.Count);

		}
		[Fact]
		public async Task testgetAllEmployeesIfNoEmployeesExist()
		{
			// Arrange
			//var em = await CreateAndSaveEmplyee();
			var employeeService = new EmployeeService(_db);

			// Act
			var Employees = await employeeService.GetEmployees();

			// Assert

			bool isEmpty = Employees.IsNullOrEmpty();
			Assert.True(isEmpty);

		}
		[Fact]
		public async Task testgetEmployeeById()
		{
			// Arrange
			await CreateAndSaveEmplyee();
			var employeeService = new EmployeeService(_db);
			// Act
			var employee = await employeeService.GetEmployee(1);
			bool result = false;
			if (employee.Name == "test1"
				&& employee.EmployeeID == 1
				&& employee.IsAvailable == true
				&& employee.GymID == 1
				&& employee.WorkingDays == "test1"
				&& employee.WorkingHours == "test1"
				&& employee.Salary == "test1"
				&& employee.JobDescription == "Instructor")
			{
				result = true;
			}
			// Assert
			Assert.True(result);
		}

		[Fact]
		public async Task testgetEmployeeByIdNotExist()
		{
			// Arrange
			await CreateAndSaveEmplyee();
			var employeeService = new EmployeeService(_db);
			// Act
			var employee = await employeeService.GetEmployee(3);

			// Assert
			Assert.Null(employee);
		}

		[Fact]
		public async Task testUpdateEmployee()
		{
			// Arrange
			await CreateAndSaveEmplyee();
			var employeeService = new EmployeeService(_db);
			UpdateEmployeeDTO updateEmployeeDTO = new UpdateEmployeeDTO()
			{
				GymID = 2,
				Name = "UpdateTest1",
				JobDescription = "Instructor",
				IsAvailable = false,
				WorkingDays = "UpdateTest1",
				WorkingHours = "UpdateTest1",
				Salary = "UpdateTest1"
			};
			// Act

			var employeeUpdated = await employeeService.Update(updateEmployeeDTO, 1);
			bool result = false;
			if (employeeUpdated.Name == "UpdateTest1"
				&& employeeUpdated.EmployeeID == 1
				&& employeeUpdated.IsAvailable == false
				&& employeeUpdated.GymID == 2
				&& employeeUpdated.WorkingDays == "UpdateTest1"
				&& employeeUpdated.WorkingHours == "UpdateTest1"
			&& employeeUpdated.Salary == "UpdateTest1"
				&& employeeUpdated.JobDescription == "Instructor")
			{
				result = true;
			}
			// Assert

			Assert.True(result);

		}

		[Fact]
		public async Task testUpdateEmployeeNotExist()
		{
			// Arrange
			await CreateAndSaveEmplyee();
			var employeeService = new EmployeeService(_db);
			UpdateEmployeeDTO updateEmployeeDTO = new UpdateEmployeeDTO()
			{
				GymID = 2,
				Name = "UpdateTest3",
				JobDescription = "Instructor",
				IsAvailable = false,
				WorkingDays = "UpdateTest3",
				WorkingHours = "UpdateTest3",
				Salary = "UpdateTest3"
			};
			//Act
			var employeeUpdated = await employeeService.Update(updateEmployeeDTO, 3);
			//Assert
			Assert.Equal(null, employeeUpdated);
		}

		[Fact]
		public async Task testDeleteEmployee()
		{
			// Arrange
			await CreateAndSaveEmplyee();
			var employeeService = new EmployeeService(_db);


			// Act
			await employeeService.Delete(1);
			var employee = await employeeService.GetEmployee(1);
			// Assert

			Assert.Null(employee);

		}

		[Fact]
		public async Task testGetEmployeesByGymId()
		{
			// Arrange
			await CreateAndSaveEmplyee();
			var employeeService = new EmployeeService(_db);
			// Act
			var employee = await employeeService.GetEmployeesByGymId(1);
			// Assert

			Assert.Equal(2, employee.Count);

		}
		[Fact]
		public async Task testGetEmployeesWhenGymIdNotExist()
		{
			// Arrange
			await CreateAndSaveEmplyee();
			var employeeService = new EmployeeService(_db);
			// Act
			var employee = await employeeService.GetEmployeesByGymId(4);
			// Assert

			Assert.Empty(employee);

		}
		[Fact]
		public async Task testGetEmployeesByGymIdWhenTheListEmpty()
		{
			// Arrange
			await CreateAndSaveEmplyee();
			var employeeService = new EmployeeService(_db);
			// Act
			var employee = await employeeService.GetEmployeesByGymId(2);
			// Assert

			Assert.Empty(employee);

		}

	}
}