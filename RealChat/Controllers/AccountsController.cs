using Microsoft.AspNetCore.Mvc;
using RealChat.Dtos;

namespace RealChat.Controllers  
{
    public class AccountsController : BaseController
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            return Ok();
        }
    }
}