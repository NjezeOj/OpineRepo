using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Opine.Shared.DTOS
{
    public class UserInfo
    {
        [Required]
        public string CustomUserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Company { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public int CompanyId { get; set; } 
    }
}
