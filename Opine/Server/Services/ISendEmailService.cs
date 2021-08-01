using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Server.Services
{
    public interface ISendEmailService
    {
        Task<bool> SendEmail(Contact contact);
    }
}
