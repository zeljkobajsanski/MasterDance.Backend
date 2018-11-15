using MasterDance.Web;
using MasterDance.Web.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MasterDance.IntegrationTests
{
    public class TestBase : IClassFixture<CustomWebApplicationFactory>
    {
        protected CustomWebApplicationFactory Factory;

        public TestBase(CustomWebApplicationFactory factory)
        {
            Factory = factory;
        }

        protected MasterDanceContext GetDb()
        {
            return this.Factory.Server.Host.Services.GetService<MasterDanceContext>();
        }
    }
}