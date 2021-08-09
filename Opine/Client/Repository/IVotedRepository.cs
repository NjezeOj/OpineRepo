using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Repository
{
    public interface IVotedRepository
    {
        Task CreateVoted(Voted voted);
        Task DeleteVoted(int id);
        Task<Voted> GetVotedById(int id, string userId);
    }
}
