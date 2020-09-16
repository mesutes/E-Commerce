using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class Customer: AuditableEntity
    {
       // public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string SurName { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public List<Adress> Addresses { get; set; }

    }
}
