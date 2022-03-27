using Models.DTOs.UsersDTOs;
using Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UsersRepo
{
    public interface IUserRepository
    {
        Task<User> GetEntity(long id); 
        Task UpdateEntity(User user); 
        Task DeleteEntity(User user); 
        Task CreateEntity(User user); 
        Task<IEnumerable<User>> ListEntities(long tenantId);
    }
}
