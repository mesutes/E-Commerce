using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class AdminLoginModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre  boş geçilemez")]
        public string Password { get; set; }

        public bool RemindMe { get; set; }

    }
}
