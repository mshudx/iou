using System;

namespace Mshudx.AspNet.Identity.DocumentDb
{
    public class IdentityUserLogin
    {
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
        public virtual string ProviderDisplayName { get; set; }
        public virtual string UserId { get; set; }
    }
}