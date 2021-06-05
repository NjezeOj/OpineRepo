using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Opine.Client.Repository;
using Opine.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Helpers.StateManagement
{
    public class UserService : IUserService
    {
        public int CompanyId;
        private readonly IUserRepository userRepository;
        [CascadingParameter] private Task<AuthenticationState> AuthenticationState { get; set; }
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<int> GetCompanyId()
        {
            var authState = await AuthenticationState;
            var user = authState.User;
            var identityName = user.Identity.Name;

            var Users = await userRepository.GetUsers();

            if (user.Identity.IsAuthenticated)
            {

                CompanyId = Users.Where(u => u.Email == identityName).Select(u => u.CompanyId).FirstOrDefault();
                return CompanyId;
            }

            else
            {
                return 0;
            }
        }
    }
}
