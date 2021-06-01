using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Opine.Shared.Entities
{
    public class Company
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Company Email is required")]
        public string Email { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
