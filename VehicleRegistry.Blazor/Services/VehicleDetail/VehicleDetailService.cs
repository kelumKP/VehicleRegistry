#region File Header
// ********************************************************************************************************************
// File: VehicleDetailService.cs
// By: Kelum
// Copyright (c) [Year] Your Company
// MIT License
// ********************************************************************************************************************
#endregion

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VehicleRegistry.Application.VehicleDetail;

namespace VehicleRegistry.Blazor.Services.VehicleDetail
{
    public class VehicleDetailService : IBaseService<VehicleDetailDto>
    {
        private readonly HttpClient _httpClient;

        public VehicleDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Adds or updates a vehicle detail.
        /// </summary>
        /// <param name="vehicleDetail">The vehicle detail to add or update.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
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
                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
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

        /// <summary>
        /// Deletes a vehicle detail by ID.
        /// </summary>
        /// <param name="id">The ID of the vehicle detail to delete.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        public async Task<bool> Delete(int id)
        {
            try
            {
                // Make an HTTP DELETE request to the DeleteVehicleDetail endpoint
                var response = await _httpClient.DeleteAsync($"API/VehicleDetail/{id}");

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

        /// <summary>
        /// Finds a vehicle detail by its ID.
        /// </summary>
        /// <param name="id">The ID of the vehicle detail to find.</param>
        /// <returns>The found vehicle detail or null if not found.</returns>
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

        /// <summary>
        /// Gets a list of all vehicle details.
        /// </summary>
        /// <returns>A list of vehicle detail items or an empty list if none found.</returns>
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
