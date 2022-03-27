
using Models.Entites;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories.UsersRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly TenantDbContext dbContext;

        public UserRepository(TenantDbContext tenantDbContext)
        {
            this.dbContext = tenantDbContext;
        }

        public async Task CreateEntity(User user)
        {
            user.CreationDate = DateTime.Now;

            this.dbContext.Users.Add(user);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<User> GetEntity(long id)
          => await this.dbContext.Users.FindAsync(id);
         
        public async Task UpdateEntity(User user)
        {
            this.dbContext.Entry<User>(user).State = EntityState.Modified;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteEntity(User user)
        { 
            this.dbContext.Users.Remove(user);

            await this.dbContext.SaveChangesAsync();
        } 

        public async Task<IEnumerable<User>> ListEntities(long tenantId)
         => await (from users in this.dbContext.Users
                    where users.TenantId == tenantId
                    select users).ToArrayAsync(); 

    }
}
