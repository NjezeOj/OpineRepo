using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Opine.Server.Entities;
using Opine.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;  
using System.Text;
using System.Threading.Tasks;

namespace Opine.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
     
        
        public AccountsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            
        }
   

        [HttpPost("Register")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
        {
            var user = new ApplicationUser { UserName= model.Email, Email = model.Email, Company= model.Company, CompanyId=model.CompanyId, CustomUserName=model.CustomUserName};
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return BuildToken(model);
            }
            else
            {
                return BadRequest("FullName or Password Invalid");
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo loginInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(loginInfo.Email, loginInfo.Password, isPersistent: false, lockoutOnFailure: false); //lockoutOnFailure: true for production

           
            if (result.Succeeded)
            {
                return BuildToken(loginInfo);
            }
            else
            {
                return BadRequest("Invalid Login Details");
            }
        }

        private UserToken BuildToken(UserInfo userinfo)
        {
            
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userinfo.Email),
                new Claim(ClaimTypes.Email, userinfo.Email),
                
            };

           

            //configuring credentials used to sign in our jwt 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,  
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
