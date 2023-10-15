using gym_management_system_front_end.Models.Models.DTOs;
using gym_management_system_front_end.Models.Models.Services;
using System.Threading.Tasks;
using Xunit;

namespace Gym_System_test
{
    public class SubscriptionTierTest : Mock
    {
        [Fact]
        public async Task Can_Add_SubscriptionTier_To_Database()
        {
            // Arrange
            var subscriptionTier = await CreateAndSaveSubscriptionTierTest();
            var service = new SubscriptionTierService(_db);

            // Act
            var actualTier = await service.GetSubscriptionTier(subscriptionTier.SubscriptionTierID);

            // Assert
            Assert.NotNull(actualTier);
            Assert.Equal(subscriptionTier.SubscriptionTierID, actualTier.SubscriptionTierID);
            Assert.Equal(subscriptionTier.Name, actualTier.Name);
            Assert.Equal(subscriptionTier.Price, actualTier.Price);
            Assert.Equal(subscriptionTier.Length, actualTier.Length);
        }

        [Fact]
        public async Task Can_Delete_SubscriptionTier_From_Database()
        {
            // Arrange
            var subscriptionTier = await CreateAndSaveSubscriptionTierTest();
            var service = new SubscriptionTierService(_db);

            // Act
            await service.DeleteSubscriptionTier(subscriptionTier.SubscriptionTierID);

            // Assert
            var deletedTier = await service.GetSubscriptionTier(subscriptionTier.SubscriptionTierID);
            Assert.Null(deletedTier);
        }

        [Fact]
        public async Task Can_Update_SubscriptionTier_In_Database()
        {
            // Arrange
            var subscriptionTier = await CreateAndSaveSubscriptionTierTest();
            var service = new SubscriptionTierService(_db);

            // Act
            var updateDto = new UpdateSubscriptionTierDTO
            {
                Name = "Updated Tier",
                Price = "Updated Price",
                Length = 60,
            };

            await service.UpdateSubscriptionTier(subscriptionTier.SubscriptionTierID, updateDto);

            // Assert
            var updatedTier = await service.GetSubscriptionTier(subscriptionTier.SubscriptionTierID);
            Assert.NotNull(updatedTier);
            Assert.Equal(updateDto.Name, updatedTier.Name);
            Assert.Equal(updateDto.Price, updatedTier.Price);
            Assert.Equal(updateDto.Length, updatedTier.Length);
        }
    }
}
