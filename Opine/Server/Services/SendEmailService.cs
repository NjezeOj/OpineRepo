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
            EmailAddress from = new EmailAddress("Njezeojin@yandex.com", "Opine Poll");
            List<EmailAddress> recipients = new List<EmailAddress> { new EmailAddress(contact.Email, contact.Name) };
            
            msg.SetSubject("Test Mail");
            msg.SetFrom(from);
            msg.AddTos(recipients);
            msg.HtmlContent = contact.Message;

            Response response = await _sendGridClient.SendEmailAsync(msg);

            /*Console.WriteLine(response.StatusCode);
            Console.WriteLine(await response.Body.ReadAsStringAsync());*/

            if (Convert.ToInt32(response.StatusCode) >= 400)
            {
                return false;
            }
            return true;
        }

    }
}
