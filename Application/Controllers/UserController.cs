using AutoMapper;
using Infrastructure.Repositories.TenantsRepo;
using Infrastructure.Repositories.UsersRepo;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.UsersDTOs;
using Models.Entites;

namespace Application.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        private readonly ITenantRepository _tenantRepository; 

        public readonly IMapper _mapper;
        public UserController(
            ITenantRepository tenantRepository, 
            IUserRepository userRepository,
            IMapper mapper)
        {
            this._tenantRepository = tenantRepository;
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
            Tenant tenant = await this._tenantRepository.GetEntity(requestDTO.TenantId);

            if (tenant == null)
                return NotFound();

            User user = this._mapper.Map<User>(requestDTO);

            await this._userRepository.CreateEntity(user);

            return CreatedAtAction(nameof(GetUserById), new
            {
                id = user.UserId
            });
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateUser(long id, UpdateUserDTO requestDTO)
        { 
            Tenant tenant = await this._tenantRepository.GetEntity(requestDTO.TenantId);

            if (tenant == null)
                return NotFound(); 

            User user =  this._mapper.Map<User>(requestDTO);

            user.UserId = id;

            if (!this._userRepository.IsUserExist(id))
                return NotFound();

            await this._userRepository.UpdateEntity(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            User user = await this._userRepository.GetEntity(id);

            if (user == null)
                return NotFound();

            await this._userRepository.DeleteEntity(user);

            return NoContent();
        }

        [HttpGet("/api/tenants/{tenantId}/users")]
        public async Task<IActionResult> ListUsers(long tenantId)
           => Ok(this._mapper.Map<IEnumerable<SelectUserDTO>>(await this._userRepository.ListEntities(tenantId)));
    }
}
