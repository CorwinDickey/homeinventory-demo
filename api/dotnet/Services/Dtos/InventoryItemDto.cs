using Domain.Inventory;

namespace Services.Dtos
{
    /// <summary>
    /// DTO for an <see cref="InventoryItem"/>
    /// </summary>
    public class InventoryItemDto
    {
        /// <summary>
        /// DB Id of the <see cref="InventoryItem"/> if it already exists in the db, otherwise null.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// ISO 8601 string of the date the item was added to the inventory.
        /// </summary>
        public string CreatedDate { get; set; }

        /// <summary>
        /// DB Id of the user who created the item in the DB.
        /// </summary>
        public int? CreatedUserId { get; set; }

        /// <summary>
        /// DB Id of the entity this entity is based on, if this entity is a modification of a previous entry. Null if newly created entity.
        /// </summary>
        public int? ParentEntityId { get; set; }

        /// <summary>
        /// ISO 8601 string of the date the entity was deleted by the user, if any.
        /// </summary>
        public string DeletedDate { get; set; }

        /// <summary>
        /// DB Id of the user who deleted the entity, if any.
        /// </summary>
        public int? DeletedUserId { get; set; }

        /// <summary>
        /// ISO 8601 string of the date the item was purchased, if known.
        /// </summary>
        public string DatePurchased { get; set; }

        /// <summary>
        /// Price the item was purchased for, if known.
        /// </summary>
        public decimal? PurchasePrice { get; set; }

        /// <summary>
        /// Location the item was purchased at, if known.
        /// </summary>
        public string PurchaseLocation { get; set; }

        /// <summary>
        /// Name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Model of the item, if any.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Serial number of the item, if any.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Brand of the item, if known.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Additional notes about the item.
        /// </summary>
        public string Notes { get; set; }
    }
}
