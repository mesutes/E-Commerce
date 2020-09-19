using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class Product : AuditableEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<ProductCategory>  ProductCategories { get; set; }
        public int inStock { get; set; }

        public decimal Price { get; set; }

    }
}
