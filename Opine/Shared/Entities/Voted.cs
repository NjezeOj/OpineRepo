using System;
using System.Collections.Generic;
using System.Text;

namespace Opine.Shared.Entities
{
    public class Voted
    {
        public int Id { get; set; }
        public bool Completed { get; set; }
        public string AppType { get; set; }/// Web or Mobile
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
