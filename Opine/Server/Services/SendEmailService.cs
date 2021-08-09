using Microsoft.Extensions.DependencyInjection;
using Opine.Shared.Entities;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Server.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly ISendGridClient _sendGridClient;

        public SendEmailService(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient ?? throw new ArgumentNullException(nameof(sendGridClient)); ;
        }

        public async Task<bool> SendEmail(Contact contact)
        {
            SendGridMessage msg = new SendGridMessage();
            EmailAddress from = new EmailAddress(contact.Email, contact.Name);
            List<EmailAddress> recipients = new List<EmailAddress> { new EmailAddress("Njezeojin@yandex.com","Ojin") };
            
            msg.SetSubject("Test Mail");
            msg.SetFrom(from);
            msg.AddTos(recipients);
            msg.PlainTextContent = contact.Message;

            Response response = await _sendGridClient.SendEmailAsync(msg);

            if (Convert.ToInt32(response.StatusCode) >= 400)
            {
                return false;
            }
            return true;
        }

    }
}
