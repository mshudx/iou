using System;
using System.Collections.Generic;

namespace Mshudx.AspNet.Identity.DocumentDb
{
    public class IdentityRole
    {
        public IdentityRole()
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Id = Guid.NewGuid().ToString();
        }

        public IdentityRole(string roleName) : this()
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Name = roleName;
        }

        public virtual ICollection<IdentityRoleClaim> Claims { get; } = new List<IdentityRoleClaim>();

        public virtual string Id { get; set; }
        public virtual string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}