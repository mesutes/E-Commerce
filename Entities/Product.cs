using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; }
        public List<Category> categories { get; set; }
        public int inStock { get; set; }



    }
}
