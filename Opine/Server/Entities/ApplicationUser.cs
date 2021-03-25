using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Server.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Company { get; set; }
        public int CompanyId { get; set; }
    }
}
