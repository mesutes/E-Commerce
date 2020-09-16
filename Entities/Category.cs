using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class Category: AuditableEntity
    {
        //public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public DateTime CreatedDate { get; } = DateTime.Now;
    

    }

}
