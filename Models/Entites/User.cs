using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entites
{
    public class User
    {
        public long UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime CreationDate { get; set; }

        public long TenantId { get; set; }

        public Tenant Tenant { get; set; }
    }
}

 