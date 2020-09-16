using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class Customer: AuditableEntity
    {
        // public string Id { get; set; } = Guid.NewGuid().ToString();
        [MaxLength(20)]
        public string Name { get; set; }
        
        [MaxLength(20)]
        public string SurName { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public List<Adress> Addresses { get; set; }

    }
}
