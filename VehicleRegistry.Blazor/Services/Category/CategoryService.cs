using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VehicleRegistry.Application.Category;

namespace VehicleRegistry.Blazor.Services.Category
{
    public class CategoryService : IBaseService<CategoryDetailsDto>
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddUpdate(CategoryDetailsDto category)
        {
            try
            {
                // Serialize the CategoryDetailsDto as JSON
                var categoryJson = JsonSerializer.Serialize(category);

                // Create a StringContent with the JSON data
                var content = new StringContent(categoryJson, Encoding.UTF8, "application/json");

                // Determine whether this is an add (POST) or update (PUT) operation based on whether the CategoryDetailsDto has an ID.
                HttpResponseMessage response;
                if (category.CategoryId > 0)
                {
                    // This is an update, so use PUT and include the ID in the URL
                    response = await _httpClient.PutAsync($"API/Category/{category.CategoryId}", content);
                }
                else
                {
                    // This is an add, so use POST
                    response = await _httpClient.PostAsync("API/Category/", content);
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

        public async Task<bool> Delete(int id)
        {
            try
            {
                // Make an HTTP DELETE request to the DeleteCategory endpoint
                var response = await _httpClient.DeleteAsync($"API/Category/{id}");

                if (response.IsSuccessStatusCode)
                {
                    // Check if the deletion was successful based on the HTTP status code (e.g., 204 No Content)
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return true;
                    }
                    else
                    {
                        // Handle the case where the request was successful but the response status code is unexpected
                        // You might want to return false or handle it differently based on your application's needs
                        return false;
                    }
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

        public async Task<CategoryDetailsDto> FindById(int id)
        {
            try
            {
                // Make an HTTP GET request to the GetCategoryById endpoint
                var response = await _httpClient.GetAsync($"API/Category/{id}");

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a CategoryDetailsDto
                    var result = await response.Content.ReadFromJsonAsync<CategoryDetailsDto>();
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

        public async Task<List<CategoryDetailsDto>> GetAllAsync()
        {
            try
            {
                // Make an HTTP GET request to your API endpoint
                var response = await _httpClient.GetAsync("API/Category");

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a List<CategoryDetailsDto>
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

