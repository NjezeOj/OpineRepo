using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Opine.Shared.Entities
{
    public class Question
    {
        public int Id { get; set; }
        [Required(ErrorMessage="This field is required")]
        public string Ques { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string A { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public DateTime UploadTime { get; set; }
    }
}
