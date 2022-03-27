using AutoMapper;
using Infrastructure.Repositories.UsersRepo;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.UsersDTOs;
using Models.Entites;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public readonly IMapper _mapper;
        public UserController(IUserRepository userRepository,
            IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            User user = await this._userRepository.GetEntity(id);

            if (user == null)
                return NotFound();

            SelectUserDTO userDTO = this._mapper.Map<SelectUserDTO>(user);

            return Ok(userDTO); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO requestDTO)
        {
            User user = this._mapper.Map<User>(requestDTO);

            await this._userRepository.CreateEntity(user);

            return CreatedAtAction(nameof(GetUserById), new
            {
                id = user.UserId
            });
        }
         
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromQuery]long id, [FromBody]UpdateUserDTO requestDTO)
        {
            User user = await this._userRepository.GetEntity(id);

            if (user == null) 
                return NotFound();

            user = this._mapper.Map<User>(requestDTO); 
             
            await this._userRepository.UpdateEntity(user);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(long id)
        {
            User user = await this._userRepository.GetEntity(id);

            if (user == null)
                return NotFound();

            await this._userRepository.DeleteEntity(user);

            return NoContent();
        }

        [HttpGet("tenants/{tenantId}/users")]
        public async Task<IActionResult> ListUsers(long tenantId)
           => Ok(this._mapper.Map<IEnumerable<SelectUserDTO>>(await this._userRepository.ListEntities(tenantId)));
    }
}
