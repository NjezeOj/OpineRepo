using System;
using System.Collections.Generic;
using System.Text;

namespace Opine.Shared.Entities
{
    public class Token
    {
        public int Id { get; set; }
        public Guid TokenId { get; set; }
        public string Email { get; set; }
        public Company Company { get; set; }
    }
}
