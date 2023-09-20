#region File Header
// ********************************************************************************************************************
// File: IconService.cs
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
using VehicleRegistry.Application.Icon;

namespace VehicleRegistry.Blazor.Services.Icon
{
    public class IconService : IBaseService<IconDto>
    {
        private readonly HttpClient _httpClient;

        public IconService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Adds or updates an icon (not implemented).
        /// </summary>
        /// <param name="item">The icon to add or update.</param>
        /// <returns>NotImplementedException</returns>
        public Task<bool> AddUpdate(IconDto item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an icon by ID (not implemented).
        /// </summary>
        /// <param name="id">The ID of the icon to delete.</param>
        /// <returns>NotImplementedException</returns>
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds an icon by its ID (not implemented).
        /// </summary>
        /// <param name="id">The ID of the icon to find.</param>
        /// <returns>NotImplementedException</returns>
        public Task<IconDto> FindById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of all icons.
        /// </summary>
        /// <returns>A list of icon details or an empty list if none found.</returns>
        public async Task<List<IconDto>> GetAllAsync()
        {
            try
            {
                // Make an HTTP GET request to your API endpoint
                var response = await _httpClient.GetAsync("API/Icon");

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a List<IconDto>
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
