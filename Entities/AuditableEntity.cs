using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class AuditableEntity:BaseEntity
    {

        protected AuditableEntity() 
        {
            this.AddedDate = DateTime.Now;
        }
        public DateTime AddedDate { get; set; }
        public DateTime ModifyDate { get; set; }
        
        [MaxLength(50)]
        public string AddedBy { get; set; }
            

    }
}
