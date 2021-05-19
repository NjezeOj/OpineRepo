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

        [HttpPost]
        public async Task<ActionResult> Post(Token token)
        {
            context.Add(token);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
