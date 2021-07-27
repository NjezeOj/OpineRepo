using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Opine.Client.Helpers;
using Opine.Server.Entities;
using Opine.Server.Helpers;
using Opine.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Opine.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserDTO>>> Get([FromQuery] PaginationDTO paginationDTO, int id)
        {
            var queryable = context.Users.Where(u => u.CompanyId == id).AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);

            return await queryable.Paginate(paginationDTO)
                .Select(x => new UserDTO { Email = x.Email, UserId = x.Id, CustomUserName = x.CustomUserName, CompanyId = x.CompanyId }).ToListAsync();
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            var queryable = context.Users.AsQueryable();
            return await queryable
                .Select(x => new UserDTO { Email = x.Email, UserId = x.Id, CustomUserName = x.CustomUserName, CompanyId = x.CompanyId }).ToListAsync();
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<RoleDTO>>> Get()
        {
            return await context.Roles
                .Select(x => new RoleDTO { RoleName = x.Name }).ToListAsync();
        }

        [HttpPost("assignRole")]
        public async Task<ActionResult> AssignRole(EditRoleDTO editRoleDTO)
        {
            var user = await userManager.FindByIdAsync(editRoleDTO.UserId);
            await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDTO.RoleName));
            return NoContent();
        }


        [HttpPost("removeRole")]
        public async Task<ActionResult> RemoveRole(EditRoleDTO editRoleDTO)
        {
            var user = await userManager.FindByIdAsync(editRoleDTO.UserId);
            await userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDTO.RoleName));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            context.Remove(user);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
