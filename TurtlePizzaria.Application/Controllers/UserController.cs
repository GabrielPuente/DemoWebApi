using System;
using System.Linq;
using TurtlePizzaria.Core.Util;
using TurtlePizzaria.Domain.Entities;
using TurtlePizzaria.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TurtlePizzaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// User
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// User list
        /// </summary>
        /// <returns>user list</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetList();
            return Ok(users);
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">id user</param>
        /// <returns>User</returns>
        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var user = _userService.Get(id);
            if (user is null)
                return BadRequest("User not found!");
            return Ok(user);
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="userSent">User obj</param>
        /// <returns>user</returns>
        [HttpPost]
        public IActionResult Post([FromBody] User userSent)
        {
            var validateResult = userSent.UserValidade();
            if (validateResult.Errors.Any())
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage));

            var user = _userService.Post(userSent);
            return Ok(user);
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="id">Id user</param>
        /// <param name="userSent">Obj user</param>
        /// <returns>user</returns>
        [HttpPut("{id:Guid}")]
        public IActionResult Put(Guid id, [FromBody] User userSent)
        {
            var user = _userService.Get(id);
            if (user is null)
                return BadRequest("User not found!");

            var validateResult = userSent.UserValidade();
            if (validateResult.Errors.Any())
                return BadRequest(validateResult.Errors.Select(x => x.ErrorMessage));

            if (!string.IsNullOrEmpty(user.Password))
                user.Password = Password.PasswordHash(user.Password);
            else
                userSent.Password = user.Password;

            userSent.Id = id;
            user = _userService.Put(userSent);
            return Ok(user);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            var user = _userService.Get(id);
            if (user is null)
                return BadRequest("User not found!");

            _userService.Delete(id);
            return Ok("User deleted!");
        }
    }
}
