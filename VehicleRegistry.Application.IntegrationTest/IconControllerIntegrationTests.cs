using System.Net.Http.Json;
using System.Net;
using VehicleRegistry.Application.Icon;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VehicleRegistry.Application.Icon.Queries.GetAllIcons;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace VehicleRegistry.Application.IntegrationTests
{
    [TestClass]
    public class IconControllerIntegrationTests
    {
        private HttpClient _httpClient;

        public IconControllerIntegrationTests()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateClient();
        }

        [TestMethod]
        public async Task GetAllIcons_ReturnsSuccessStatusCode()
        {
            // Act: Send an HTTP GET request to the GetAllIcons endpoint
            var response = await _httpClient.GetAsync("/API/Icon");

            // Assert: Check if the response is successful (status code 200 OK)
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            // You can add more assertions based on your application's behavior
            // For example, you can deserialize the response to check its content:
            var icons = await response.Content.ReadFromJsonAsync<List<IconDto>>();
            Assert.IsNotNull(icons);
            Assert.IsTrue(icons.Count > 0);
        }
    }
}