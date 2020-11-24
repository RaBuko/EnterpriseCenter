using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnterpriseCenterWebIntegrationTests
{
    public class BasicTests : IClassFixture<WebApplicationFactory<EnterpriseCenterWeb.Startup>>
    {
        private readonly WebApplicationFactory<EnterpriseCenterWeb.Startup> _factory;

        public BasicTests(WebApplicationFactory<EnterpriseCenterWeb.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/customers")]
        public async Task Get_EntpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
