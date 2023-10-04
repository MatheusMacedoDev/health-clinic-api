using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;
using webapi.health.clinic.ViewModels;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public LoginController()
        {
            _userRepository = new UserRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel data)
        {
            try
            {
                User matchedUser = _userRepository.GetByEmailAndPassword(data.Email!, data.Password!);
                
                if (matchedUser == null)
                {
                    return NotFound("Dados inválidos");
                }

                // Create token

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, matchedUser.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, matchedUser.Email!),
                    new Claim(ClaimTypes.Role, matchedUser.UserType!.TypeName!)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("health-clinic-authentication-webapi-dev"));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(issuer: "webapi.health.clinic", audience: "webapi.health.clinic", claims: claims, expires: DateTime.Now.AddMinutes(5), signingCredentials: credentials);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
