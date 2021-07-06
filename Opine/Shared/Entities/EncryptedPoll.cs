using System;
using System.Collections.Generic;
using System.Text;

namespace Opine.Shared.Entities
{
    public class EncryptedPoll
    {
        public int Id { get; set; }
        public string Option { get; set; }
        public byte Count { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
