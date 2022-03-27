using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entites
{
    public class Tenant
    {
        public long TenantId { get; set; } 
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
 
