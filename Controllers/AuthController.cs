using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagerAPI.Enums;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // Sample users list (in place of DB for demo)
        private readonly List<User> _users = new()
        {
            new User { Id = 1, Username = "admin", Password = "admin@123", Role = UserRole.Admin },
            new User { Id = 2, Username = "user", Password = "user@123", Role = UserRole.User }
        };

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto loginDto)
        {
            var user = _users.SingleOrDefault(x =>
                x.Username == loginDto.Username && x.Password == loginDto.Password);

            if (user == null)
                return Unauthorized(new { message = "Invalid username or password" });

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is a super secret key for jwt"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString });
        }
    }

    // DTO used for login
    public class UserLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
