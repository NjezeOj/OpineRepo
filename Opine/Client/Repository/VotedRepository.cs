using Opine.Client.Helpers;
using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Repository
{
    public class VotedRepository : IVotedRepository
    {
        private readonly IHttpService httpService;
        private readonly string baseURL = "api/voted";
        public VotedRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task CreateVoted(Voted voted)
        {
            var response = await httpService.Post(baseURL, voted);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<List<Voted>> GetVotedById(int id)
        {
            return await httpService.GetHelper<List<Voted>>(baseURL, id);
        }
    }
}
