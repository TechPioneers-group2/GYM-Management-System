using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Services;

namespace Gym_System_test
{
    public class clientTest : Mock
    {
        [Fact]
        public async Task getallClients()
        {
            var clientdb = new ClientService(_db);
            var client = await createClientAndSave();
            var clients = await clientdb.GetClients(client.GymID);
            Assert.Equal(1, clients.Count);
        }

        [Fact]
        public async Task getallclientsfalse()
        {
            var clientdb = new ClientService(_db);
            // var client = await createClientAndSave();
            var clients = await clientdb.GetClients(9);
            Assert.Empty(clients);

        }


        [Fact]
        public async Task getclientbyid()
        {
            var clientdb = new ClientService(_db);
            var client = await createClientAndSave();
            var newclient = await clientdb.GetClient( client.ClientID , client.GymID);

            Assert.Equal("test", newclient.Name);

        }




        [Fact]
        public async Task getclientbyidfalse()
        {

            var clientdb = new ClientService(_db);

            var newclient = await clientdb.GetClient(5, 6);
            Assert.Null(newclient);


        }


        [Fact]
        public async Task updateclient()
        {
            var clientdb = new ClientService(_db);
            var client = await createClientAndSave();
            var newclient = await clientdb.UpdateClient(client.ClientID, client.GymID, new UpdateClientDTO
            {
                InGym = true,
                SubscriptionTierID=1

            } );

            // Assert.False(newclient.InGym == client.InGym  && client.SubscriptionTierID == newclient.SubscriptionTierID);
            Assert.True(newclient.InGym);
        }

        [Fact]
        public async Task deleteclient()
        {
            var clientdb = new ClientService(_db);
            var client = await createClientAndSave();
            var newclient = await clientdb.GetClient(client.ClientID, client.GymID);
            await clientdb.DeleteClient(newclient.ClientID, newclient.GymID);
            var deletedone = await clientdb.GetClient(client.ClientID, client.GymID);
            Assert.Null(deletedone);
        }
    }
}



