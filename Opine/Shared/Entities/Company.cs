using System;
using System.Collections.Generic;
using System.Text;

namespace Opine.Shared.Entities
{
    public class Company
    {
        public int id { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<Question> Questions { get; set; }
    }
}
