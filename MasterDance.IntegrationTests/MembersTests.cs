using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using MasterDance.Web.Features.Members.Queries;
using Xunit;

namespace MasterDance.IntegrationTests
{
    public class MembersTests : TestBase
    {
        public MembersTests(CustomWebApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async void GetMembers()
        {
            var client = Factory.CreateClient();
            var response = await client.GetAsync("/api/Members");
            
            Assert.True(response.StatusCode == HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<IList<GetMembers.Model>>();
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void GetMemberById()
        {
            var client = Factory.CreateClient();
            var response = await client.GetAsync("/api/Members/1");

            Assert.True(response.StatusCode == HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<GetMemberById.Model>();
            Assert.NotNull(result);
            Assert.Equal("Jovana", result.FirstName);
            Assert.Equal("Bajsanski", result.LastName);
        }
    }
}