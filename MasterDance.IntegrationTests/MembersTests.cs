using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MasterDance.Web.Data;
using MasterDance.Web.Features.Members.Commands;
using MasterDance.Web.Features.Members.Queries;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MasterDance.IntegrationTests
{
    public class MembersTests : TestBase
    {
        public MembersTests(CustomWebApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async void CrudTests()
        {
            await GetMembers();
            await GetMemberById();
            await InsertMember();
            await UpdateMember();
        }

        public async Task GetMembers()
        {
            var client = Factory.CreateClient();
            var response = await client.GetAsync("/api/Members");
            
            Assert.True(response.StatusCode == HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<IList<GetMembers.Model>>();
            Assert.Equal(2, result.Count);
        }

        public async Task GetMemberById()
        {
            var client = Factory.CreateClient();
            var response = await client.GetAsync("/api/Members/1");

            Assert.True(response.StatusCode == HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<GetMemberById.Dto>();
            Assert.NotNull(result);
            Assert.Equal("Jovana", result.FirstName);
            Assert.Equal("Bajsanski", result.LastName);
        }

        public async Task InsertMember()
        {
            // Arrange
            var client = Factory.CreateClient();
            var request = new SaveMember.Dto()
            {
                FirstName = "Jovana",
                LastName = "Bajsanski",
                Image = "jovana.jpg",
                ContactAddress = "Preradoviceva 36/17",
                DateOfBirth = new DateTime(2010, 11, 25),
                FatherFirstName = "Zeljko",
                FatherContactPhone = "+381 63 528065",
                MotherFirstName = "Ivana",
                MotherContactPhone = "+381 63 518 885",
            };
            
            // Act
            var response = await client.PostAsJsonAsync("api/members", request);
            
            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
        
        public async Task UpdateMember()
        {
            // Arrange
            var client = Factory.CreateClient();
            var request = new SaveMember.Dto()
            {
                Id = 1,
                FirstName = "Jovana Joca",
                LastName = "Bajsanski",
                Image = "jovana.jpg"
            };
            
            // Act
            var response = await client.PostAsJsonAsync("api/members", request);
            
            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}