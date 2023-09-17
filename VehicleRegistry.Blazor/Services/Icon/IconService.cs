using System.Net.Http;
using System.Net.Http.Json;
using VehicleRegistry.Application.Icon;
using VehicleRegistry.Application.VehicleDetail;

namespace VehicleRegistry.Blazor.Services.Icon
{
    public class IconService : IBaseService<IconDto>
    {
        private readonly HttpClient _httpClient;

        public IconService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> AddUpdate(IconDto item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IconDto> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IconDto>> GetAllAsync()
        {
            try
            {
                // Make an HTTP GET request to your API endpoint
                var response = await _httpClient.GetAsync("API/Icon");

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a List<VehicleDetailDto>
                    var result = await response.Content.ReadFromJsonAsync<List<IconDto>>();
                    return result ?? new List<IconDto>(); // Return the deserialized data or an empty list if null
                }
                else
                {
                    // Handle the error case, for example, log or throw an exception
                    // You might want to return an empty list or handle it differently based on your application's needs
                    return new List<IconDto>();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the HTTP request
                // You might want to log the exception or throw it further up
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<IconDto>();
            }
        }
    }
}
