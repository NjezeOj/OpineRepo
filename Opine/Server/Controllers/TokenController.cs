using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Opine.Client.Helpers;
using Opine.Server.Helpers;
using Opine.Shared.DTOS;
using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController :  ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TokenController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Token>>> Get()
        {
            return await context.Tokens.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Token>>> Get([FromQuery] PaginationDTO paginationDTO, int id) //company id will compared with question company id
        {

            var queryable = context.Tokens.Where(q => q.CompanyId == id).AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);

            return await queryable.Paginate(paginationDTO).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Token token)
        {
            context.Add(token);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var token  = await context.Tokens.FirstOrDefaultAsync(x => x.Id == id);
            if (token == null)
            {
                return NotFound();
            }

            context.Remove(token);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
