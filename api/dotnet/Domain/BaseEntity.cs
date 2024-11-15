using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Base attributes required for an entity
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// The DB Id of the entity
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
