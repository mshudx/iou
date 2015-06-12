using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IouOne.WebApp.Models
{
    public class User
    {
        public List<string> ExternalTokens { get; set; }
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Bio { get; set; }
    }
}
