using Domain.Inventory;
using Domain.User;
using Services.Dtos;

namespace Services.Interfaces
{
    /// <summary>
    /// Defines the methods available to work with <see cref="InventoryItem"/>s in the application.
    /// </summary>
    public interface IInventoryItemService
    {
        /// <summary>
        /// Creates a new inventory item and adds it to the DB.
        /// </summary>
        /// <param name="itemDto">Data model containing information about the item to be created.</param>
        /// <returns><see cref="InventoryItemDto"/> with metadata after creation.</returns>
        Task<InventoryItemDto> CreateAsync(InventoryItemDto itemDto);

        /// <summary>
        /// Creates a new entity with updated data, maintains original data for history and auditing.
        /// </summary>
        /// <param name="user">User updating the item.</param>
        /// <param name="itemDto">Data model containing updated item information.</param>
        /// <returns><see cref="InventoryItemDto"/> with data for new record and Id of original entity for historical data/auditing.</returns>
        Task<InventoryItemDto> UpdateAsync(
            ApplicationUser user, InventoryItemDto itemDto);

        /// <summary>
        /// Creates a new entity with deleted properties set, maintains original data for history and auditing.
        /// </summary>
        /// <param name="user">User deleting the item.</param>
        /// <param name="id">DB Id of the item being deleted.</param>
        /// <returns>Empty task</returns>
        Task DeleteAsync(ApplicationUser user, int id);

        /// <summary>
        /// Gets a list of all current inventory items that the user has access to
        /// </summary>
        /// <param name="user">User requesting items</param>
        /// <returns>List of <see cref="InventoryItemDto"/></returns>
        ICollection<InventoryItemDto> GetAll(ApplicationUser user);

        /// <summary>
        /// Gets a list of all inventory items and their historical records that the user has access to
        /// </summary>
        /// <param name="user">User requesting items</param>
        /// <returns>List of <see cref="InventoryItemDto"/></returns>
        ICollection<InventoryItemDto> GetAllWithHistory(ApplicationUser user);

        /// <summary>
        /// Gets a list of all deleted inventory items that the user has access to
        /// </summary>
        /// <param name="user">User requesting items</param>
        /// <returns>List of <see cref="InventoryItemDto"/></returns>
        ICollection<InventoryItemDto> GetAllDeleted(ApplicationUser user);
    }
}
