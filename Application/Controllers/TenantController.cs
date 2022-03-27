using AutoMapper;
using Infrastructure.Repositories.TenantsRepo;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.TenantsDTOs;
using Models.Entites;

namespace Application.Controllers
{
    [Route("api/tenants")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantRepository _tenantRepository;

        public readonly IMapper _mapper;
        public TenantController(ITenantRepository tenantRepository,
            IMapper mapper)
        {
            this._tenantRepository = tenantRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateTenantDTO requestDTO)
        {
            Tenant tenant = this._mapper.Map<Tenant>(requestDTO);

            await this._tenantRepository.CreateEntity(tenant);

            return CreatedAtAction(nameof(GetTenantById), new
            {
                id = tenant.TenantId
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTenantById(long id)
        {
            Tenant tenant = await this._tenantRepository.GetEntity(id);

            if (tenant == null)
                return NotFound();

            SelectTenantDTO tenantDTO =
                this._mapper.Map<SelectTenantDTO>(tenant);

            return Ok(tenantDTO);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateTenant(long id, UpdateTenantDTO requestDTO)
        {
            if (!this._tenantRepository.IsTenantExist(id))
                return NotFound();

            Tenant tenant = this._mapper.Map<Tenant>(requestDTO);

            tenant.TenantId = id;

            await this._tenantRepository.UpdateEntity(tenant);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenant(long id)
        {
            Tenant tenant = await this._tenantRepository.GetEntity(id);

            if (tenant == null)
                return NotFound();

            await this._tenantRepository.DeleteEntity(tenant);

            return NoContent();
        }

        [HttpGet("/api/tenants")]
        public async Task<IActionResult> ListTenants()
        {
            //List to excel.
            IEnumerable<SelectTenantDTO> tenants =
                this._mapper.Map<IEnumerable<SelectTenantDTO>>(await this._tenantRepository.ListEntities());

            return Ok(tenants);
        }
    }
}
