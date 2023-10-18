//using GYM_Management_System.Models.DTOs;
//using GYM_Management_System.Models.Services;

//namespace Gym_System_test
//{
//    public class GymEquipmentsTests : Mock
//    {
//        [Fact]
//        public async Task CanCreateAndDeleteGymEquipment()
//        {
//            // Arrange
//            var gymEquipmentService = new GymEquipmentsService(_db);

//            // Act
//            var createdGymEquipment = await gymEquipmentService.Create(new CreatEquipmentDTO
//            {
//                Name = "Test Equipment",
//                Quantity = 10,
//                OutOfService = 0,
//                GymID = 1

//            });

//            // Assert
//            var createdEquipmentId = createdGymEquipment.GymEquipmentID;
//            Assert.NotEqual(0, createdEquipmentId);

//            await gymEquipmentService.DeleteGymEquipment(createdEquipmentId);

//            var deletedEquipment = await gymEquipmentService.GetEquipmentById(createdEquipmentId);
//            Assert.Null(deletedEquipment);
//        }

//        [Fact]
//        public async Task CanUpdateGymEquipment()
//        {
//            // Arrange
//            var gymEquipmentService = new GymEquipmentsService(_db);
//            var gymEquipment = await CreateAndSaveGymEquipmentTest();

//            // Act
//            await gymEquipmentService.UpdateGymEquipment(gymEquipment.GymEquipmentID, new EquipmentDTOPutservice
//            {
//                Quantity = 5,
//                OutOfService = 1
//            });

//            // Assert
//            var updatedGymEquipment = await gymEquipmentService.GetEquipmentById(gymEquipment.GymEquipmentID);
//            Assert.NotNull(updatedGymEquipment);
//            Assert.Equal(5, updatedGymEquipment.Quantity);
//            Assert.Equal(1, updatedGymEquipment.OutOfService);
//        }


//    }
//}
