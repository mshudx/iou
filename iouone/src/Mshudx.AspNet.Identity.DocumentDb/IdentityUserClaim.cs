using System;
using Newtonsoft.Json;

namespace Mshudx.AspNet.Identity.DocumentDb
{
    public class IdentityUserClaim
    {
        [JsonProperty(PropertyName = "id")]
        public virtual int Id { get; set; }

        public virtual string UserId { get; set; }

        public virtual string ClaimType { get; set; }

        public virtual string ClaimValue { get; set; }
    }
}