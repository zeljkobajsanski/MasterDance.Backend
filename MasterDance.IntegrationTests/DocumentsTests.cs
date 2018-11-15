using System.Collections.Generic;
using System.Net.Http;
using MasterDance.Web.Features.Documents.Queries;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Xunit;

namespace MasterDance.IntegrationTests
{
    public class DocumentsTests : TestBase
    {
        public DocumentsTests(CustomWebApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async void GetDocumentTypes()
        {
            var client = Factory.CreateClient();
            
            var responseMessage = await client.GetAsync("api/documents/GetDocumentTypes");
            
            Assert.True(responseMessage.IsSuccessStatusCode);
            var documentTypes = await responseMessage.Content.ReadAsAsync<IList<GetDocumentTypes.Model>>();
            Assert.Equal(2, documentTypes.Count);
        }
    }
}