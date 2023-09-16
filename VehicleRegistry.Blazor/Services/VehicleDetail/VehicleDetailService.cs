using System;
using VehicleRegistry.Application.Category;
using VehicleRegistry.Application.VehicleDetail;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;

namespace VehicleRegistry.Blazor.Services.VehicleDetail
{
    public class VehicleDetailService : IBaseService<VehicleDetailDto>
    {
        private readonly HttpClient _httpClient;

        public VehicleDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public bool AddUpdate(VehicleDetailDto vehicleDetail)
        {
            // Implement the AddUpdate logic here
            return true; // Replace with your logic
        }

        public bool Delete(int id)
        {
            // Implement the Delete logic here
            return true; // Replace with your logic
        }

        public VehicleDetailDto FindById(int id)
        {
            // Implement the FindById logic here
            // Return an instance of the Person class
            return new VehicleDetailDto(); // Replace with actual data retrieval logic
        }

        public async Task<List<VehicleDetailDto>> GetAllAsync()
        {
            try
            {
                // Make an HTTP GET request to your API endpoint
                var response = await _httpClient.GetAsync("API/VehicleDetail");

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a List<VehicleDetailDto>
                    var result = await response.Content.ReadFromJsonAsync<List<VehicleDetailDto>>();
                    return result ?? new List<VehicleDetailDto>(); // Return the deserialized data or an empty list if null
                }
                else
                {
                    // Handle the error case, for example, log or throw an exception
                    // You might want to return an empty list or handle it differently based on your application's needs
                    return new List<VehicleDetailDto>();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the HTTP request
                // You might want to log the exception or throw it further up
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<VehicleDetailDto>();
            }
        }
    }
}
