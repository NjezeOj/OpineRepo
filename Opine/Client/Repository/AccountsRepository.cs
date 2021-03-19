using Opine.Client.Helpers;
using Opine.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Repository
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly IHttpService _httpService;
        private readonly string baseURL = "api/accounts";

        public AccountsRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }
            
        public async Task<UserToken> Register(UserInfo userInfo)
        {
            var httpResponse = await _httpService.Post<UserInfo, UserToken>($"{baseURL}/Register", userInfo);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }

            return httpResponse.Response;
        }

        public async Task<UserToken> Login(UserInfo userInfo)
        {
            var httpResponse = await _httpService.Post<UserInfo, UserToken>($"{baseURL}/Login", userInfo);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }

            return httpResponse.Response;
        }
    }
}
