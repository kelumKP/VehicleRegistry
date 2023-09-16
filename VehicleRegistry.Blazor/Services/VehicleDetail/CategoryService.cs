using System.Net.Http;
using System.Net.Http.Json;
using VehicleRegistry.Application.Category;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.Blazor.Services.VehicleDetail
{
    public class CategoryService : IBaseService<CategoryDetailsDto>
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> AddUpdate(CategoryDetailsDto item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDetailsDto FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryDetailsDto>> GetAllAsync()
        {
            try
            {
                // Make an HTTP GET request to your API endpoint
                var response = await _httpClient.GetAsync("API/Category");

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a List<VehicleDetailDto>
                    var result = await response.Content.ReadFromJsonAsync<List<CategoryDetailsDto>>();
                    return result ?? new List<CategoryDetailsDto>(); // Return the deserialized data or an empty list if null
                }
                else
                {
                    // Handle the error case, for example, log or throw an exception
                    // You might want to return an empty list or handle it differently based on your application's needs
                    return new List<CategoryDetailsDto>();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the HTTP request
                // You might want to log the exception or throw it further up
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<CategoryDetailsDto>();
            }
        }
    }
}
