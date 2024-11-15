using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Inventory
{
    /// <summary>
    /// Stores data associated with an item in the home inventory
    /// </summary>
    [Table("InventoryItems", Schema = Schemas.Inventory)]
    public class InventoryItem : AuditableEntity
    {
        /// <summary>
        /// The date the inventory item was purchased
        /// </summary>
        public DateTimeOffset? DatePurchased { get; set; }

        /// <summary>
        /// The price the inventory item was purchased for
        /// </summary>
        public decimal? PurchasePrice { get; set; }

        /// <summary>
        /// The location the inventory item was purchased at (could be a website)
        /// </summary>
        public string PurchaseLocation { get; set; }

        /// <summary>
        /// The name of the inventory item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The model (if applicable) of the inventory item
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// The serial number (if applicable) of the inventory item
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// The brand of the inventory item
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// A collection of files associated with the inventory item
        /// </summary>
        public ICollection<ItemFile> Files { get; set; }
    }
}
