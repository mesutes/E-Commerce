using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class PhoneNumber: AuditableEntity
    {
        [MaxLength(15)]
        public string CellPhoneNumber { get; set; }
        public Customer Customer { get; set; }

        public int CustomerID { get; set; }
            
    }
}
