using GYM_Management_System.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_System_test
{
    public class SupplementsTests : Mock
    {

        [Fact]
        public async Task CanAddASupplementToDataBase()
        {
            // Arrange
            var supplement = await CreateAndSaveSupplementTest();

            // Act
            var supplementService = new SupplementService(_db);

            // Assert
            var actualSupplement = await supplementService.GetSupplementById(supplement.SupplementID);
            Assert.Equal(supplement.SupplementID, actualSupplement.SupplementID);
            Assert.Equal(supplement.Name, actualSupplement.Name);
            Assert.Equal(supplement.Price, actualSupplement.Price);
        }

        [Fact]
        public async Task CanAddAndDeleteSupplementFromDataBase()
        {
            // Arrange
            var supplement = await CreateAndSaveSupplementTest();
            var supplementService = new SupplementService(_db);

            // Act
            await supplementService.DeleteSupplement(supplement.SupplementID);

            // Assert
            var deletedSupplement = await supplementService.GetSupplementById(supplement.SupplementID);
            Assert.Null(deletedSupplement);
        }
    }
}
