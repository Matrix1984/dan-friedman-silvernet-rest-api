using Microsoft.EntityFrameworkCore;
using Models.Entites;

namespace Infrastructure.Repositories.TenantsRepo
{
    public class TenantRepository : ITenantRepository
    {
        private readonly TenantDbContext dbContext;
        public TenantRepository(TenantDbContext tenantDbContext)
        {
            this.dbContext = tenantDbContext;
        }

        public async Task CreateEntity(Tenant tenant)
        {
            this.dbContext.Tenants.Add(tenant);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Tenant> GetEntity(long id)
          => await this.dbContext.Tenants.FindAsync(id); 

        public async Task UpdateEntity(Tenant tenant)
        {
            this.dbContext.Entry<Tenant>(tenant).State = EntityState.Modified;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteEntity(Tenant tenant)
        {
            this.dbContext.Tenants.Remove(tenant);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tenant>> ListEntities()
          => await (from ten in this.dbContext.Tenants
                          select ten).ToArrayAsync(); 


    }
}
