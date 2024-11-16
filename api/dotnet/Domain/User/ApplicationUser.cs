using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User
{
    /// <summary>
    /// A user of the application
    /// </summary>
    [Table("Users", Schema = Schemas.User)]
    public class ApplicationUser : AuditableEntity
    {
        /// <summary>
        /// The user's unique Id in the authentication tenant/source
        /// </summary>
        public string AuthId { get; set; }

        /// <summary>
        /// The user's display name to be used in the application
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The user's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The user's login records
        /// </summary>
        public ICollection<LoginRecord> LoginRecords { get; set; }
            = new List<LoginRecord>();
    }
}
