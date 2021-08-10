using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Opine.Server.Services;
using Opine.Shared.DTOS;
using Opine.Shared.Entities;
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

        public SendEmailController(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService ?? throw new ArgumentNullException(nameof(sendEmailService));
            
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
           

        }
    }
}
