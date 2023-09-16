using System.Net.Http;
using System.Net.Http.Json;
using VehicleRegistry.Application.VehicleDetail;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.Blazor.Services.VehicleDetail
{
    public class ManufacturerService : IBaseService<Manufacturer>
    {
        private readonly HttpClient _httpClient;

        public ManufacturerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public bool AddUpdate(Manufacturer item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Manufacturer FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Manufacturer>> GetAllAsync()
        {
            try
            {
                // Make an HTTP GET request to your API endpoint
                var response = await _httpClient.GetAsync("API/Manufacturer");

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a List<VehicleDetailDto>
                    var result = await response.Content.ReadFromJsonAsync<List<Manufacturer>>();
                    return result ?? new List<Manufacturer>(); // Return the deserialized data or an empty list if null
                }
                else
                {
                    // Handle the error case, for example, log or throw an exception
                    // You might want to return an empty list or handle it differently based on your application's needs
                    return new List<Manufacturer>();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the HTTP request
                // You might want to log the exception or throw it further up
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Manufacturer>();
            }
        }
    }
}
