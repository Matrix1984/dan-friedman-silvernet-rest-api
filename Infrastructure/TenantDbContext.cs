using Microsoft.EntityFrameworkCore;
using Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
