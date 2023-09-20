#region File Header
// ********************************************************************************************************************
// File: ManufacturerService.cs
// By: Kelum
// Copyright (c) [Year] Your Company
// MIT License
// ********************************************************************************************************************
#endregion

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VehicleRegistry.Application.Manufacturer;

namespace VehicleRegistry.Blazor.Services.Manufacturer
{
    public class ManufacturerService : IBaseService<ManufacturerDto>
    {
        private readonly HttpClient _httpClient;

        public ManufacturerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Adds or updates a manufacturer (not implemented).
        /// </summary>
        /// <param name="item">The manufacturer to add or update.</param>
        /// <returns>NotImplementedException</returns>
        public Task<bool> AddUpdate(ManufacturerDto item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a manufacturer by ID (not implemented).
        /// </summary>
        /// <param name="id">The ID of the manufacturer to delete.</param>
        /// <returns>NotImplementedException</returns>
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds a manufacturer by its ID (not implemented).
        /// </summary>
        /// <param name="id">The ID of the manufacturer to find.</param>
        /// <returns>NotImplementedException</returns>
        public Task<ManufacturerDto> FindById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of all manufacturers.
        /// </summary>
        /// <returns>A list of manufacturer details or an empty list if none found.</returns>
        public async Task<List<ManufacturerDto>> GetAllAsync()
        {
            try
            {
                // Make an HTTP GET request to your API endpoint
                var response = await _httpClient.GetAsync("API/Manufacturer");

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a List<ManufacturerDto>
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
