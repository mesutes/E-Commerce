using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class Adress: AuditableEntity
    {
        //public string Id { get; set; } = Guid.NewGuid().ToString();
        [MaxLength(250)]
        public string Adres { get; set; }
        public Customer Customer { get; set; }


    }
}
