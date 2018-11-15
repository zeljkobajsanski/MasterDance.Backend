using MasterDance.Web;
using Microsoft.AspNetCore.Mvc.Testing;
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
    }
}