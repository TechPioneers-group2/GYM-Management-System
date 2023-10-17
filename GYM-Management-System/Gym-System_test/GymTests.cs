
using gym_management_system_front_end.Models.Models;
using gym_management_system_front_end.Models.Models.DTOs;
using gym_management_system_front_end.Models.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_System_test
{
    public class GymTests : Mock
    {

        [Fact]
        public async void TestGetAllGyms()
        {
            var subTeir = new SubscriptionTierService(_db);
            var clientservice = new ClientService(_db);
            var gymservice = new GymService(_db, subTeir, clientservice);
            var GymList = new List<PostGymDTO>()
            {
                new PostGymDTO(){ Name="test1" , Address="Amman", ActiveHours="2-5",MaxCapacity="120", CurrentCapacity=20, Notification="none"},
                                new PostGymDTO(){ Name="test2" , Address="Amman", ActiveHours="2-5",MaxCapacity="120", CurrentCapacity=20, Notification="none"},
                                                new PostGymDTO(){ Name="test3" , Address="Amman", ActiveHours="2-5",MaxCapacity="120", CurrentCapacity=20, Notification="none"},

            };
            var Gymlist = await gymservice.GetGyms();
            Assert.Equal(GymList.Count, Gymlist.Count);
        }

        [Fact]
        public async void TestAddNewGym()
        {
            var gym = await TestCreateGym()
;




            var subTeir = new SubscriptionTierService(_db);
            var clientservice = new ClientService(_db);
            var gymservice = new GymService(_db, subTeir, clientservice);
            var gymid = await gymservice.GetGym(gym.GymID);
            var gymList = await gymservice.GetGyms();


            Assert.Equal(4, gymList.Count);


        }

        [Fact]
        public async void TestingDeleteGym()
        {
            var gym = await TestCreateGym();
            var subTeir = new SubscriptionTierService(_db);
            var clientservice = new ClientService(_db);
            var gymservice = new GymService(_db, subTeir, clientservice);
            await gymservice.DeleteGym(gym.GymID);
            var gymList = await gymservice.GetGyms();
            var deletedGym = await gymservice.GetGym(gym.GymID);
            Assert.Null(deletedGym);
            Assert.Equal(3, gymList.Count);

        }

        [Fact]
        public async void TestForUpdatingGym()
        {
            var gym = await TestCreateGym();
            var subTeir = new SubscriptionTierService(_db);
            var clientservice = new ClientService(_db);
            var gymservice = new GymService(_db, subTeir, clientservice);
            var UpdatedGym = new PutGymDTO() { Address = "UpdatedAdress", ActiveHours = "UpdatedTime", MaxCapacity = "200", CurrentCapacity = 20, Notification = "none" };
            var newUpdted = await gymservice.UpdateGym(gym.GymID, UpdatedGym);
            Assert.NotNull(newUpdted);
            Assert.Equal("UpdatedAdress", newUpdted.Address);
            Assert.Equal("UpdatedTime", newUpdted.ActiveHours);
        }


        [Fact]
        public async Task TestForAddSupplementsToGym()
        {
            // Arrange
            var gym = await TestCreateGym();
            var supplement = await CreateNewGymSupplement();
            var subTeir = new SubscriptionTierService(_db);
            var clientservice = new ClientService(_db);
            var gymservice = new GymService(_db, subTeir, clientservice);

            var newGymSupplement = new UpdateGymSupplementDTO
            {
                Quantity = 10
            };

            // Act
            await gymservice.AddSupplementToGym(gym.GymID, supplement.SupplementID, newGymSupplement);
            var updatedGym = await gymservice.GetGym(gym.GymID);

            // Assert
            Assert.NotNull(updatedGym.Supplements);
            Assert.Single(updatedGym.Supplements);
            Assert.Equal(supplement.SupplementID, updatedGym.Supplements[0].SupplementID);
            Assert.Equal(newGymSupplement.Quantity, updatedGym.Supplements[0].Quantity);
        }

        [Fact]
        public async Task TestForUpdatingSupplementForGym()
        {
            // Arrange
            var gym = await TestCreateGym();
            var supplement = await UpdateGymSupplement();
            var subTeir = new SubscriptionTierService(_db);
            var clientservice = new ClientService(_db);
            var gymservice = new GymService(_db, subTeir, clientservice);

            var updatedQuantity = 30; // Adjust the updated quantity as needed
            var updateGymSupplement = new UpdateGymSupplementDTO
            {
                Quantity = updatedQuantity
            };

            // Act
            await gymservice.UpdateSupplementForGym(gym.GymID, supplement.SupplementID, updateGymSupplement);
            var updatedGymSupplement = await _db.GymSupplements.FirstOrDefaultAsync(
                gs => gs.GymID == gym.GymID && gs.SupplementID == supplement.SupplementID);

            // Assert
            Assert.NotNull(updatedGymSupplement);
            Assert.Equal(updatedQuantity, updatedGymSupplement.Quantity);
        }

        [Fact]
        public async Task TestForDeletingSupplementFromGym()
        {
            // Arrange
            var supplement = await CreateNewGymSupplement();
            var gym = await TestCreateGym();

            var subTeir = new SubscriptionTierService(_db);
            var clientservice = new ClientService(_db);
            var gymservice = new GymService(_db, subTeir, clientservice);

            // Act
            await gymservice.RemoveSupplementFromGym(gym.GymID, supplement.SupplementID);
            var updatedGym = await gymservice.GetGym(gym.GymID);

            // Assert
            var removedSupplement = updatedGym.Supplements.Find(s => s.SupplementID == supplement.SupplementID);
            Assert.Null(removedSupplement);
        }
    }
}
