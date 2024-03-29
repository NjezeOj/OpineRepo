﻿using Opine.Client.Helpers;
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

        public async Task<Voted> GetVotedById(int id, string userId)
        {
            var response = await httpService.Get<Voted>($"{baseURL}/{id}/{userId}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task<int> GetNumberOfVotes(int id)
        {
            var response = await httpService.Get<int>($"{baseURL}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task DeleteVoted(int id)
        {
            var response = await httpService.Delete($"{baseURL}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
