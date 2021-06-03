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
    public class CompanyController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CompanyController(ApplicationDbContext context)
        {
            this.context = context;
        }

       /* [HttpGet]
        public async Task<ActionResult<List<Company>>> Get()
        {
            return await context.Companies.ToListAsync();
        }*/

        [HttpGet]
        public async Task<ActionResult<List<Company>>> Get([FromQuery]PaginationDTO paginationDTO)
        {
            var queryable = context.Companies.AsQueryable();//making queries to specific type
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);

            return await queryable.Paginate(paginationDTO).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Company company)
        {
            context.Add(company);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
