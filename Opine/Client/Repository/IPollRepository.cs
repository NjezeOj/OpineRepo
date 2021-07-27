using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Repository
{
    public interface IPollRepository
    {
        Task CreatePoll(Poll poll);
        Task DeletePoll(int id);
        Task<List<Poll>> GetPoll();
        Task<List<Poll>> GetPollsById(int id);
        Task UpdatePoll(Poll poll);
    }
}
