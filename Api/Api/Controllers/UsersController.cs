using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

using System.Collections.Specialized;

using Models;
using Services;
using System.Text.Json;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return Ok(await userService.GetUsers());
        }

        [HttpGet("authorize/{id}")]
        public async Task<IActionResult> Authorize([FromRoute] string id)
        {
            var user = await userService.GetUser(id);

            if (user != null)
            {

                Response.Cookies.Append("session", JsonSerializer.Serialize(user), new CookieOptions {
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
                    HttpOnly= true
                });
                
                return Ok();
            }

            return BadRequest($"No user of ${id} was found in the database");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] string id)
        {
            return Ok(await userService.GetUser(id));
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            return Ok(await userService.AddUser(user));
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser([FromBody] User user)
        {
            await userService.UpdateUser(user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] string id)
        {
            await userService.DeleteUser(id);

            return Ok();
        }
    }
}