using Opine.Client.Helpers;
using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IHttpService httpService;
        private readonly string baseURL = "api/sendemail";

        public EmailRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<bool> SendEmail(Contact contact)
        {
            var response = await httpService.Post($"{baseURL}/contact", contact);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Success;
        }
    }
}
