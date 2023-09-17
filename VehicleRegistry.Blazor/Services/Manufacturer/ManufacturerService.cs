using System.Net.Http;
using System.Net.Http.Json;
using VehicleRegistry.Application.Manufacturer;
using VehicleRegistry.Application.VehicleDetail;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.Blazor.Services.Manufacturer
{
    public class ManufacturerService : IBaseService<ManufacturerDto>
    {
        private readonly HttpClient _httpClient;

        public ManufacturerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> AddUpdate(ManufacturerDto item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ManufacturerDto> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ManufacturerDto>> GetAllAsync()
        {
            try
            {
                // Make an HTTP GET request to your API endpoint
                var response = await _httpClient.GetAsync("API/Manufacturer");

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a List<VehicleDetailDto>
                    var result = await response.Content.ReadFromJsonAsync<List<ManufacturerDto>>();
                    return result ?? new List<ManufacturerDto>(); // Return the deserialized data or an empty list if null
                }
                else
                {
                    // Handle the error case, for example, log or throw an exception
                    // You might want to return an empty list or handle it differently based on your application's needs
                    return new List<ManufacturerDto>();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the HTTP request
                // You might want to log the exception or throw it further up
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<ManufacturerDto>();
            }
        }
    }
}
