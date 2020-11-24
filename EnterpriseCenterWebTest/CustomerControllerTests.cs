using EnterpriseCenterWeb;
using EnterpriseCenterWeb.Models;
using EnterpriseCenterWebIntegrationTests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Net.Http;
using Xunit;

namespace EnterpriseCenterWebTest
{
    [Collection("Customer Controller Tests")]
    public class CustomerControllerTests : IClassFixture<EnterpriseCenterWebFactory<Startup>>
    {
        private readonly EnterpriseCenterWebFactory<Startup> _factory;
        private readonly HttpClient _client;

        public CustomerControllerTests(EnterpriseCenterWebFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async void Get_customers()
        {
            //Arrange+
            var defaultPage = await _client.GetAsync("/customers");
        }
    }
}
