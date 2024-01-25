using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Text;
using zesty_api.Data;
using zesty_api.Data.Entities;
using zesty_api.Interfaces;
using zesty_api.Models;

namespace zesty_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) 
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public ActionResult<User> Register([FromBody] User request)
        {
            try
            {
                var registerUser = _authService.Register(request);
                return Ok(registerUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] LoginUser request)
        {
            try
            {
                var token = _authService.Login(request);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
