using Microsoft.AspNetCore.Mvc;

using Models;
using Services;

namespace Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserService userService) : ControllerBase {

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers(){
            return Ok(await userService.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] string id){
            return Ok(await userService.GetUser(id));
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user){
            return Ok(await userService.AddUser(user));
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser([FromBody] User user){
            await userService.UpdateUser(user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] string id){
            await userService.DeleteUser(id);

            return Ok();
        }
    }   
}