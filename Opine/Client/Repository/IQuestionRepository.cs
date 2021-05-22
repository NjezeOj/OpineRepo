using Opine.Shared.DTOS;
using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Repository
{
    public interface IQuestionRepository
    {
        Task CreateQuestion(Question quest);
        Task<List<Question>> GetQuestions();
        Task<PaginatedResponse<List<Question>>> GetQuestionsyId(PaginationDTO paginationDTO, int id);
    }
}
