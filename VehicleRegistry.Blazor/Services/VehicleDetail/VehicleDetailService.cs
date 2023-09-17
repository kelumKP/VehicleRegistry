using System;
using VehicleRegistry.Application.Category;
using VehicleRegistry.Application.VehicleDetail;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace VehicleRegistry.Blazor.Services.VehicleDetail
{
    public class VehicleDetailService : IBaseService<VehicleDetailDto>
    {
        private readonly HttpClient _httpClient;

        public VehicleDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddUpdate(VehicleDetailDto vehicleDetail)
        {
            try
            {
                // Serialize the VehicleDetailDto as JSON
                var vehicleDetailJson = JsonSerializer.Serialize(vehicleDetail);

                // Create a StringContent with the JSON data
                var content = new StringContent(vehicleDetailJson, Encoding.UTF8, "application/json");

                // Determine whether this is an add (POST) or update (PUT) operation based on whether the VehicleDetailDto has an ID.
                HttpResponseMessage response;
                if (vehicleDetail.VehicleDetailId > 0)
                {
                    // This is an update, so use PUT and include the ID in the URL
                    response = await _httpClient.PutAsync($"API/VehicleDetail/{vehicleDetail.VehicleDetailId}", content);
                }
                else
                {
                    // This is an add, so use POST
                    response = await _httpClient.PostAsync("API/VehicleDetail/", content);
                }

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Handle the error case, for example, log or throw an exception
                    // You might want to return false or handle it differently based on your application's needs
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the HTTP request
                // You might want to log the exception or throw it further up
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VehicleDetailDto> FindById(int id)
        {
            try
            {
                // Make an HTTP GET request to the GetVehicleDetailById endpoint
                var response = await _httpClient.GetAsync($"API/VehicleDetail/{id}");

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a VehicleDetailDto
                    var result = await response.Content.ReadFromJsonAsync<VehicleDetailDto>();
                    return result; // Return the deserialized data
                }
                else
                {
                    // Handle the error case, for example, log or throw an exception
                    // You might want to return null or handle it differently based on your application's needs
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the HTTP request
                // You might want to log the exception or throw it further up
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
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
