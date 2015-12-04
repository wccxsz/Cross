using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cross.WebHost.Entities
{
    public class RoleClaim
    {
        /// <summary>
        /// Gets or sets the identifier for this role claim.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the role associated with this claim.
        /// </summary>
        public virtual Role Role { get; set; }

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
