using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class AddProductModel
    {
        [Required(ErrorMessage ="Ürün adı boş geçilemez.")]
        public string Name { get; set; }
        [Range(1,double.MaxValue,ErrorMessage ="Fiyat 0 dan yüksek olmalısınız")]
        public decimal Price { get; set; }
        public IFormFile Picture { get; set; }


    }
}
