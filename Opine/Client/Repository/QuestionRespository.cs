using Opine.Client.Helpers;
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
        string url = "api/questions";
        public QuestionRespository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<Question>> GetQuestions()
        {
            var response = await httpService.Get<List<Question>>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task CreateQuestion(Question quest)
        {
            var response = await httpService.Post(url, quest);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
