using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cross.WebHost.Entities
{
    public class UserClaim 
    {
        /// <summary>
        /// Gets or sets the identifier for this user claim.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the of the primary key of the user associated with this claim.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the claim type for this claim.
        /// </summary>
        public virtual string ClaimType { get; set; }

        /// <summary>
        /// Gets or sets the claim value for this claim.
        /// </summary>
        public virtual string ClaimValue { get; set; }
    }
}
