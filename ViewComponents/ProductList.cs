using E_Commerce.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ViewComponents
{
    public class ProductList:ViewComponent
    {
        private readonly IProductRepository _productRepository;
        public ProductList(IProductRepository _productRepository) 
        {
            this._productRepository = _productRepository;
        }

        public IViewComponentResult Invoke() 
        {
            return View(_productRepository.GetAll());
        }
    }
}
