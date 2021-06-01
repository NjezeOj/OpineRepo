using Opine.Shared.DTOS;
using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Repository
{
    public interface ITokenRepository
    {
        Task CreateToken(Token token);
        Task DeleteToken(int Id);
        Task<List<Token>> Get();
        Task<PaginatedResponse<List<Token>>> GetTokensyId(PaginationDTO paginationDTO, int id);
    }
}
