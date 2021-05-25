using Opine.Client.Helpers;
using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Repository
{
    public class PollRepository:IPollRepository
    {
        private readonly IHttpService httpService;
        private readonly string baseURL = "api/poll";
        public PollRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<List<Poll>> GetPoll()
        {
            return await httpService.GetHelper<List<Poll>>(baseURL);
        }

        public async Task CreatePoll(Poll poll)
        {
            var response = await httpService.Post(baseURL, poll);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<List<Poll>> GetPollsById(int id)
        {
            return await httpService.GetHelper<List<Poll>>(baseURL, id);
        }


    }
}
