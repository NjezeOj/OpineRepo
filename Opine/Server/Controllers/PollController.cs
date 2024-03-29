﻿using Microsoft.AspNetCore.Mvc;
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
    public class PollController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PollController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Poll>>> Get()
        {
            return await context.Polls.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<Poll>>> Get(int id)
        {
            var queryable = context.Polls.Where(q => q.Question.CompanyId == id).AsQueryable();
            return await queryable.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Poll poll)
        {
            context.Add(poll);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Poll poll)
        {
            context.Attach(poll).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var polls = await context.Polls.Where(p => p.QuestionId == id).ToListAsync();

            if(polls == null)
            {
                return NotFound();
            }

            foreach (var poll in polls)
            {
                context.Remove(poll);
            }
           
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
