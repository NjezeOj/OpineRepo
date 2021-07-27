using Opine.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Repository
{
    public interface IUserRepository
    {
        Task AssignRole(EditRoleDTO editRoleDTO);
        Task<List<RoleDTO>> GetRoles();
        Task<PaginatedResponse<List<UserDTO>>> GetUsersById(PaginationDTO paginationDTO, int id);
        Task<List<UserDTO>> GetUsers();
        Task RemoveRole(EditRoleDTO editRoleDTO);
        Task DeleteUser(string id);
    }
}
