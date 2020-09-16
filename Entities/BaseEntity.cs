using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class BaseEntity
    {
                public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
