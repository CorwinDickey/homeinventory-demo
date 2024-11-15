using Domain.MetaData;

namespace Domain.Inventory
{
    /// <summary>
    /// Holds the relationship between a <see cref="FileBlob"/> and an <see cref="InventoryItem"/>
    /// </summary>
    public class ItemFile : AuditableEntity
    {
        /// <summary>
        /// The DB Id of the FileBlob associated with the item
        /// </summary>
        public int FileBlobId { get; set; }

        /// <summary>
        /// The FileBlob entity associated with the item
        /// </summary>
        public FileBlob FileBlob { get; set; }

        /// <summary>
        /// The DB Id of the inventory item the FileBlob is associated with
        /// </summary>
        public int InventoryItemId { get; set; }

        /// <summary>
        /// The InventoryItem entity the file blob is associated with
        /// </summary>
        public InventoryItem InventoryItem { get; set; }
    }
}
