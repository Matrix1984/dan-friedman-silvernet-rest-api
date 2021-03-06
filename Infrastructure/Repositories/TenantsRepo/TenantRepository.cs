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
            tenant.CreationDate = DateTime.Now;

            this.dbContext.Tenants.Add(tenant);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Tenant> GetEntity(long id)
          => await this.dbContext.Tenants.FindAsync(id);

        public bool IsTenantExist(long id)
        {
            return (from n in this.dbContext.Tenants
                    where n.TenantId == id
                    select n).AsNoTracking().FirstOrDefault() != null;
        }

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
