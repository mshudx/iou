using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace Mshudx.AspNet.Identity.DocumentDb
{
    public class IdentityUser
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual DateTimeOffset? LockoutEnd { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual int AccessFailedCount { get; set; }
        public virtual List<UserLoginInfo> Logins { get; } = new List<UserLoginInfo>();
        public virtual List<IdentityUserClaim> Claims { get; } = new List<IdentityUserClaim>();
        public virtual List<string> Roles { get; } = new List<string>();
        public string NormalizedUserName { get; set; }
        public string NormalizedEmail { get; set; }

        public IdentityUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        public IdentityUser(string userName)
            : this()
        {
            UserName = userName;
        }

        public override string ToString()
        {
            return UserName;
        }
    }
}
