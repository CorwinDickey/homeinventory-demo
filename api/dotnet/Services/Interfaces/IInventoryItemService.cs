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
        /// <param name="user">User creating the item.</param>
        /// <param name="itemDto">Data model containing information about the item to be created.</param>
        /// <returns><see cref="InventoryItemDto"/> with metadata after creation.</returns>
        InventoryItemDto CreateInventoryItem(
            ApplicationUser user, InventoryItemDto itemDto);

        /// <summary>
        /// Creates a new entity with updated data, maintains original data for history and auditing.
        /// </summary>
        /// <param name="user">User updating the item.</param>
        /// <param name="itemDto">Data model containing updated item information.</param>
        /// <returns><see cref="InventoryItemDto"/> with data for new record and Id of original entity for historical data/auditing.</returns>
        InventoryItemDto UpdateInventoryItem(
            ApplicationUser user, InventoryItemDto itemDto);

        /// <summary>
        /// Creates a new entity with deleted properties set, maintains original data for history and auditing.
        /// </summary>
        /// <param name="user">User deleting the item.</param>
        /// <param name="id">DB Id of the item being deleted.</param>
        void DeleteInventoryItem(
            ApplicationUser user, int id);
    }
}
