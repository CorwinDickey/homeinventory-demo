using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User
{
    /// <summary>
    /// The login record for a particular user
    /// </summary>
    public class LoginRecord : BaseEntity
    {
        /// <summary>
        /// The DB Id of the logged in user
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The user entity that logged in
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// The timestamp the user logged in
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }
    }
}
