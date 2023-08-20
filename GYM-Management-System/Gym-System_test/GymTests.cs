using GYM_Management_System.Models;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Services;
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
            var clientservice = new ClientService(_db, subTeir);
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
            var clientservice = new ClientService(_db, subTeir);
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
            var clientservice = new ClientService(_db, subTeir);
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
            var clientservice = new ClientService(_db, subTeir);
            var gymservice = new GymService(_db, subTeir, clientservice);
            var UpdatedGym = new PutGymDTO() { Address = "UpdatedAdress", ActiveHours = "UpdatedTime", MaxCapacity = "200", CurrentCapacity = 20, Notification = "none" };
            var newUpdted = await gymservice.UpdateGym(gym.GymID, UpdatedGym);
            Assert.NotNull(newUpdted);
            Assert.Equal("UpdatedAdress", newUpdted.Address);
            Assert.Equal("UpdatedTime", newUpdted.ActiveHours);
        }
        [Fact]
        public async void TestForAddSupplements()
        {


            var supplement = await CreateNewGymSupplement();

            var gym = await TestCreateGym();
            var subTeir = new SubscriptionTierService(_db);
            var clientservice = new ClientService(_db, subTeir);
            var gymservice = new GymService(_db, subTeir, clientservice);
            await gymservice.AddSupplementToGym(gym.GymID, supplement.SupplementID, supplement.Quantity);
            var sup = gym.GymSupplements;
            Assert.NotNull(gym.GymSupplements);
            Assert.Equal(sup.Count, 1);


        }
        [Fact]
        public async void TestForUpdatingSuppForGym()
        {
            var supplement = await CreateNewGymSupplement();

            var gym = await TestCreateGym();
            var subTeir = new SubscriptionTierService(_db);
            var clientservice = new ClientService(_db, subTeir);
            var gymservice = new GymService(_db, subTeir, clientservice);
            await gymservice.AddSupplementToGym(gym.GymID, supplement.SupplementID, supplement.Quantity);
            var UpdatedGmSupplement = new UpdateGymSupplementDTO()
            {
                Quantity = 20,
            };
       var updated=     await gymservice.UpdateSupplementForGym(gym.GymID, supplement.SupplementID, UpdatedGmSupplement);
            Assert.Equal(updated.Quantity, 20);

        }
        [Fact]
        public async void TestForDeleteGymSupplement()
        {

            var supplements = await CreateNewGymSupplement();

            var Gym = await TestCreateGym();
            var subTeir = new SubscriptionTierService(_db);
            var clientservice = new ClientService(_db, subTeir);
            var gymservice = new GymService(_db, subTeir, clientservice);

          
            await gymservice.AddSupplementToGym(Gym.GymID, supplements.SupplementID, supplements.Quantity);
            await gymservice.RemoveSupplementFromGym(Gym.GymID , supplements.SupplementID);
            var updatedGym = await gymservice.GetGym(Gym.GymID);

            
            Assert.Empty(updatedGym.Supplements);


        }
    }
}
