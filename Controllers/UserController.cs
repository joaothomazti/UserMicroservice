using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using UserMicroservice.Interface;
using UserMicroservice.middleware;
using UserMicroservice.Models;

namespace UserMicroservice.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService = null!;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user?.Name))
                {
                    return BadRequest("The name field is required");
                }

                var createdUser = await _userService.CreateUser(user);
                return CreatedAtAction(nameof(CreateUser), new { createdUser.Id }, createdUser);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetUser(int Id)
        {
            try
            {
                var user = await _userService.GetUser(Id);
                return user == null ? throw new Exception($"User ID {{Id}} not found") : (ActionResult<User>)user;
            }
            catch (UserNotFoundException)
            {
                return NotFound("No such user found");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int Id, User user)
        {
            try
            {
                var UpdatedUser = await _userService.UpdateUser(Id, user);
                return Ok(UpdatedUser);
            }
            catch (UserNotFoundException)
            {
                return NotFound("No such user found");
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteUser(int Id)
        {
            try
            {
                var deletedUser = await _userService.DeleteUser(Id);
                if (deletedUser)
                {
                    return Ok("UserDeleted");
                }
                else
                {
                    return NotFound("UserNotFound");
                }
            }
            catch (UserNotFoundException)
            {
                return NotFound("UserNotFound");
            }
        }
    }
}