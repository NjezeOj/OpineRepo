using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Opine.Shared.Entities
{
    public class Contact
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Message { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string RecipientName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string RecipientMail { get; set; }
    }
}
