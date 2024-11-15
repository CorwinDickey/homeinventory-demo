using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// The base for an entity that is auditable, should be used for most entities instead of the <see cref="BaseEntity"/> class.
    /// </summary>
    public abstract class AuditableEntity : BaseEntity
    {
        /// <summary>
        /// The timestamp the entity was created
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }

        /// <summary>
        /// The DB Id of the user that created the entity
        /// </summary>
        public int CreatedUserId { get; set; }

        /// <summary>
        /// The DB Id of the parent entity if this entity is a modification of an existing entity (for auditing/history purposes)
        /// </summary>
        public int? ParentEntityId { get; set; }

        /// <summary>
        /// The timestamp the entity was "deleted" at
        /// </summary>
        public DateTimeOffset? DeletedDate { get; set; }

        /// <summary>
        /// The DB Id of the user who "deleted" the entity
        /// </summary>
        public int? DeletedUserId { get; set; }
    }
}
