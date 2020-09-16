using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class CustomerAdress:AuditableEntity
    {
        public  Customer customer { get; set; }
        public string CustomerID { get; set; }

        public List<Adress> adresses { get; set; }
    }
}
