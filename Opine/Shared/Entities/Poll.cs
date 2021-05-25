using System;
using System.Collections.Generic;
using System.Text;

namespace Opine.Shared.Entities
{
    public class Poll
    {
        public int Id { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        

    }
}
