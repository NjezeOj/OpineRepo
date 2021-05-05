using Opine.Client.Helpers;
using Opine.Shared.DTOS;
using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Repository
{
    public class CompanyRepository: ICompanyRepository
    {
        public readonly IHttpService httpService;
        private readonly string baseURL = "api/company";

        public CompanyRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        /*public async Task<List<Company>> Get()
        {
            var response = await httpService.Get<List<Company>>(baseURL);

             
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }*/

        public async Task<PaginatedResponse<List<Company>>> GetCompanies(PaginationDTO paginationDTO)
        {
            return await httpService.GetHelper<List<Company>>(baseURL, paginationDTO);
        }

        public async Task CreateCompany(Company company)
        {
            var response = await httpService.Post(baseURL, company);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
