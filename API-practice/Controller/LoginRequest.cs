using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace API_practice.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class LoginRequest : ControllerBase
    {
        private IConfiguration _config;
        public LoginRequest(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest loginRequest) 
        {
            /// dont forget to implement sign in auth below
            /// 
            /// 
            /// end of sign in auth

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var SecToken = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            null,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

            var token
        }
    }
}