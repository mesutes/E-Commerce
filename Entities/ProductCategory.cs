using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class ProductCategory:AuditableEntity
    {
        public  Product Product { get; set; }

        public int ProductID { get; set; }
        public Category Category { get; set; }

        public int CategoryID { get; set; }
    }
}
