using Opine.Client.Helpers;
using Opine.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpService httpService;
        private readonly string baseURL = "api/users";
        public UserRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<PaginatedResponse<List<UserDTO>>> GetUsers(PaginationDTO paginationDTO)
        {
            return await httpService.GetHelper<List<UserDTO>>(baseURL, paginationDTO);
        }

        public async Task<List<RoleDTO>> GetRoles()
        {
            return await httpService.GetHelper<List<RoleDTO>>($"{baseURL}/roles");
        }

        public async Task AssignRole(EditRoleDTO editRoleDTO)
        {
            var response = await httpService.Post($"{baseURL}/assignRole", editRoleDTO);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task RemoveRole(EditRoleDTO editRoleDTO)
        {
            var response = await httpService.Post($"{baseURL}/assignRole", editRoleDTO);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

    }
}
