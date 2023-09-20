#region File Header
// ********************************************************************************************************************
// File: IBaseService.cs
// By: Kelum
// Copyright (c) [Year] Your Company
// MIT License
// ********************************************************************************************************************
#endregion

using System.Collections.Generic;
using System.Threading.Tasks;

namespace VehicleRegistry.Blazor.Services
{
    /// <summary>
    /// Generic interface for CRUD (Create, Read, Update, Delete) operations on entities.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public interface IBaseService<T>
    {
        /// <summary>
        /// Adds or updates an entity.
        /// </summary>
        /// <param name="item">The entity to add or update.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        Task<bool> AddUpdate(T item);

        /// <summary>
        /// Deletes an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        Task<bool> Delete(int id);

        /// <summary>
        /// Finds an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to find.</param>
        /// <returns>The found entity or null if not found.</returns>
        Task<T> FindById(int id);

        /// <summary>
        /// Gets a list of all entities.
        /// </summary>
        /// <returns>A list of entity items or an empty list if none found.</returns>
        Task<List<T>> GetAllAsync();
    }
}
