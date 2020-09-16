using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class Category : AuditableEntity
    {
        //public string Id { get; set; } = Guid.NewGuid().ToString();
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<ProductCategory>  ProductCategories { get; set; }


    }

}
