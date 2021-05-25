using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class VotedController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public VotedController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Voted>>> Get(int id)
        {
            var queryable = context.Votes.Where(q => q.Question.CompanyId == id).AsQueryable();
            return await queryable.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Voted voted)
        {
            context.Add(voted);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
