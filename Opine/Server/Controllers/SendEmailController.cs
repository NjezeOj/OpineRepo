using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Opine.Server.Services;
using Opine.Shared.DTOS;
using Opine.Shared.Entities;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Opine.Server.Controllers
{
    
    [Route("api/[Controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly ISendEmailService _sendEmailService;
        private readonly IConfiguration configuration;

        public SendEmailController(ISendEmailService sendEmailService, IConfiguration configuration)
        {
            _sendEmailService = sendEmailService ?? throw new ArgumentNullException(nameof(sendEmailService));
            this.configuration = configuration;
        }

        [HttpPost("contact")]
        public async Task<ActionResult> SendEmail([FromBody] Contact contact)
        {
            try
            {
                if (string.IsNullOrEmpty(contact.Email) || string.IsNullOrEmpty(contact.Message) || string.IsNullOrEmpty(contact.Name))
                {
                    return BadRequest();
                }

                bool response = await _sendEmailService.SendEmail(contact);
                if (response)
                {
                    return Ok();
                }
                else
                {

                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            //var apiKey = Environment.GetEnvironmentVariable("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");

            /* var client = new SendGridClient(apiKey);
             var msg = new SendGridMessage()
             {
                 From = new EmailAddress(contact.Email, contact.Name),
                 Subject = "Sending with Twilio SendGrid is Fun",
                 PlainTextContent = contact.Message,

             };
             msg.AddTo(new EmailAddress("njezeojinnaka@gmail.com", "Test User"));
             await client.SendEmailAsync(msg).ConfigureAwait(false);

             return Ok();*/

        }
    }
}
