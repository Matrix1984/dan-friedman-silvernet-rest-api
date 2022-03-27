using Models.DTOs.TenantsDTOs;
using Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.TenantsRepo
{
    public interface ITenantRepository
    {
        Task<Tenant> GetEntity(long id);

        Task UpdateEntity(Tenant tenant);

        Task DeleteEntity(Tenant tenant);

        Task CreateEntity(Tenant tenant);

        Task<IEnumerable<Tenant>> ListEntities();

        bool IsTenantExist(long id);
    }
}
