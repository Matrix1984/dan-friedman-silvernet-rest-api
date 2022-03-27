using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        public TenantController()
        {

        } 

        [HttpPost]
        public async Task<IActionResult> CreateUser()
        {
            return Ok();
        }


        [HttpGet("{userId}")]
        public async Task<IActionResult> GetTenantById(long userId)
        {
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTenant()
        {
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTenant()
        {
            return NoContent();
        }

        [HttpGet("ListTenants")]
        public async Task<IActionResult> ListTenants()
        {
            return Ok();
        }
    }
}
