using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class Order : AuditableEntity
    {
        List<Product> products { get; set; }
        Customer customer { get; set; }



    }
}
