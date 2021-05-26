using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace Opine.Client.Helpers.StateManagement
{
    public class QuestionService
    {
       
        public TimeSpan TimeCreated(DateTime uploadTime)
        {
            TimeSpan diff = DateTime.Now - uploadTime;
            return diff;
        }

   
    }
}
