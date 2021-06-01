using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Opine.Shared.Entities
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string Ques { get; set; }
        [Required]
        public string A { get; set; }
        [Required]
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string QuestionUserName { get; set; }
        public DateTime UploadTime { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        
    }
}
