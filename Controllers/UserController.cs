using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

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
            if (string.IsNullOrWhiteSpace(user?.name))
            {
                return BadRequest("The name field is required");
            }

            var createdUser = await _userService.CreateUser(user);
            return CreatedAtAction(nameof(CreateUser), new { id = createdUser.id }, createdUser);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<User>> UpdateUser(int id, User user)
    {
        try
        {
            var UpdatedUser = await _userService.UpdateUser(id, user);
            return Ok(UpdatedUser);
        }
        catch (UserNotFoundException)
        {
            return BadRequest("No such user found");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        try
        {
            var deletedUser = await _userService.DeleteUser(id);
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