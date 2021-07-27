using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Opine.Client.Helpers;
using Opine.Server.Helpers;
using Opine.Shared.Entities;
using Opine.Shared.DTOS;
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
        

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Question>>> Get([FromQuery]PaginationDTO paginationDTO,  int id) //company id will compared with question company id
        {
            
            var queryable = context.Questions.Where(q => q.CompanyId == id).AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);

            return await queryable.Paginate(paginationDTO).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Question quest)
        {
            context.Add(quest);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var question = await context.Questions.FirstOrDefaultAsync(x => x.Id == id);
            if(question == null)
            {
                return NotFound();
            }

            context.Remove(question);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
