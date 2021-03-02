using System;
using System.Collections.Generic;
using System.Text;

namespace Opine.Shared.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public List<Question> Questions { get; set; }
    }
}
