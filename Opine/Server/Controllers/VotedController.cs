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

        [HttpGet("{id}/{userId}")]
        public async Task<ActionResult<Voted>> Get(int id, string userId)
        {
            var vote = await(context.Votes.Where(q => q.QuestionId == id).Where(q => q.UserId == userId)).FirstOrDefaultAsync();
            return vote;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Voted voted)
        {
            context.Add(voted);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var votes = await context.Votes.Where(x => x.QuestionId == id).ToListAsync();

            foreach(var vote in votes)
            {
                context.Remove(vote);
            }

            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
