using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models;
using GYM_Management_System.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM_Management_System.Data;

using GYM_Management_System.Models.Interfaces;
using Moq;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

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
            var newclient = await clientdb.GetClient( client.GymID , client.ClientID);

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
            var newclient = await clientdb.UpdateClient(client.GymID, client.ClientID, new UpdateClientDTO
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
            var newclient = await clientdb.GetClient( client.GymID , client.ClientID);
            await clientdb.DeleteClient(newclient.GymID, newclient.ClientID);
            var deletedone = await clientdb.GetClient(client.ClientID, client.GymID);
            Assert.Null(deletedone);
        }
    }
}



