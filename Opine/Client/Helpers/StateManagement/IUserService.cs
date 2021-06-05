using Opine.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Helpers.StateManagement
{
    public interface IUserService
    {
        Task<int> GetCompanyId();
    }
}
