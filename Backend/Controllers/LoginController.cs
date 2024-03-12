using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost, Route("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                if(string.IsNullOrEmpty(loginDTO.Usuario) || string.IsNullOrEmpty(loginDTO.Password))
                {
                    return BadRequest("Usuario y/o contraseña no especificados.");
                }

                if(loginDTO.Usuario.Equals("Us3r") && loginDTO.Password.Equals("P4ssw0rd"))
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var jwtSecurityToken = new JwtSecurityToken(
                        issuer: _config["Jwt:Issuer"],
                        audience: _config["Jwt:Audience"],
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddDays(7),
                        signingCredentials: signinCredentials);
                    return Ok(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));
                }
            }
            catch
            {
                return BadRequest("Ocurrió un error al generar el token");
            }
            return Unauthorized();

        }

    }
}
