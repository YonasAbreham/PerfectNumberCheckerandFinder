using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using PerfectNumber.API;
using Xunit;

namespace PerfectNumber.IntegrationTests
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_SwaggerEndpointReturnsSuccessResult()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/swagger");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Contains("swagger", content);
        }
 
        [Theory]
        [InlineData("/api/perfectnumber/checkWithFactors?number=5")]
        [InlineData("/api/perfectnumber/checkWithPrimeNumber?number=7")]
        [InlineData("/api/perfectnumber/find?start=5&end=6")]
        public async Task Get_APIEndpointsReturnSuccess(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
        }
   }
}
