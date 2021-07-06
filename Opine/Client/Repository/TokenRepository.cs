using Opine.Client.Helpers;
using Opine.Shared.DTOS;
using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Repository
{
    public class TokenRepository : ITokenRepository
    {
        public readonly IHttpService httpService;
        private readonly string baseURL = "api/token";

        public TokenRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<Token>> Get()
        {
            var response = await httpService.Get<List<Token>>(baseURL);


            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task CreateToken(Token token)
        {
            var response = await httpService.Post(baseURL, token);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<PaginatedResponse<List<Token>>> GetTokensyId(PaginationDTO paginationDTO, int id)
        {
            return await httpService.GetHelper<List<Token>>(baseURL, paginationDTO, id);
        }

        public async Task DeleteToken(int id)
        {
            var response = await httpService.Delete($"{baseURL}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
