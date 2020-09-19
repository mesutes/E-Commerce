using E_Commerce.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ViewComponents
{
    public class CategoryList:ViewComponent
    {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryList(ICategoryRepository _categoryRepository) 
        {
            this._categoryRepository = _categoryRepository;
        }

        public IViewComponentResult Invoke() 
        {
            return View(_categoryRepository.GetAll());
        }
    }
}
