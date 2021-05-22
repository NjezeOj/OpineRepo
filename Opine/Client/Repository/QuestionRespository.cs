using Opine.Client.Helpers;
using Opine.Shared.DTOS;
using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Repository
{
    public class QuestionRespository: IQuestionRepository
    {
        private readonly IHttpService httpService;
        private readonly string baseURL = "api/questions";
        public QuestionRespository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<Question>> GetQuestions()
        {
            var response = await httpService.Get<List<Question>>(baseURL);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task CreateQuestion(Question quest)
        {
            var response = await httpService.Post(baseURL, quest);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<PaginatedResponse<List<Question>>> GetQuestionsyId(PaginationDTO paginationDTO, int id)
        {
            return await httpService.GetHelper<List<Question>>(baseURL, paginationDTO, id);
        }

        
    }
}
