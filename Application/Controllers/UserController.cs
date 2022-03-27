using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser()
        {
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUser()
        {
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            return NoContent();
        }

        [HttpGet("ListUsers")]
        public async Task<IActionResult> ListUsers(long tenantId)
        {
            return Ok();
        }
    }
}
