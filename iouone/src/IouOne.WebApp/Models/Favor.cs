using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IouOne.WebApp.Models
{
    public class Favor
    {
        public Guid FromUser { get; set; }
        public Guid ToUser { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Description { get; set; }
    }
}
