using TurtlePizzaria.Core.Util;
using TurtlePizzaria.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TurtlePizzaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// AuthenticationC
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="configuration"></param>
        public AuthenticationController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>user + token</returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromForm] string email, [FromForm] string password)
        {
            var user = _userService.GetByEmail(email);

            if (user is null)
                return BadRequest("User not found!");

            if (!Password.CheckPassword(password, user.Password))
                return BadRequest("Password incorrect!");

            var key = _configuration["Authentication:Secret"];
            var token = JwtToken.GenerateToken(user.Name, key);

            user.Password = "";

            var json = new
            {
                user,
                token
            };

            return Ok(json);
        }
    }
}