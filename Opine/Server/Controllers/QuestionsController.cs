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
    public class QuestionsController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public QuestionsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Question>>> Get()
        {
            return await context.Questions.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Question quest)
        {
            context.Add(quest);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
