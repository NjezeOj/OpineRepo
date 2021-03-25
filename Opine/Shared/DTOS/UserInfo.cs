using System;
using System.Collections.Generic;
using System.Text;

namespace Opine.Shared.DTOS
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; } 
        public string Password { get; set; }
        public int CompanyId { get; set; }
    }
}
