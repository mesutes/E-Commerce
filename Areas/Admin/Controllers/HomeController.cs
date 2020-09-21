using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Entities;
using E_Commerce.Interfaces;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Areas.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(_productRepository.GetAll());
        }

        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository _productRepository ) 
        {
            this._productRepository = _productRepository;
        }

        public IActionResult Add() 
        { 
            return View(new AddProductModel());
        }

        [HttpPost]
        public IActionResult Add(AddProductModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.Name = model.Name;
                product.Price = model.Price;

                if (model.Picture != null)
                {
                    var extension = Path.GetExtension(model.Picture.FileName);
                    var newPictureName = Guid.NewGuid() + extension;
                    var destination = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + newPictureName);

                    var stream = new FileStream(destination, FileMode.Create);
                    model.Picture.CopyTo(stream);

                    product.Picture = newPictureName;
                }
                _productRepository.Add(product);

                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View();
        }

        
        public IActionResult Update(int id) 
        {
            var product = _productRepository.GetEntity(id);

            UpdateProductModel model = new UpdateProductModel();

            model.Id = product.Id;
            model.Name = product.Name;
            model.Price = product.Price;

            return View(model);
        }
        [HttpPost]
        public IActionResult Update(UpdateProductModel model)
        {
            if (ModelState.IsValid) 
            {
                Product product = _productRepository.GetEntity(model.Id);
                if (model.Picture != null)
                {
                    var extension = Path.GetExtension(model.Picture.FileName);
                    var newPictureName = Guid.NewGuid() + extension;
                    var destination = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + newPictureName);

                    var stream = new FileStream(destination, FileMode.Create);
                    model.Picture.CopyTo(stream);

                    product.Picture = newPictureName;
                }

                product.Name = model.Name;
                product.Price = model.Price;
                
                _productRepository.Update(product);

                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            return View(model);
        }

        public IActionResult Delete(int Id) 
        {

            _productRepository.Delete(new Product { Id = Id });
            return RedirectToAction("Index");
            
     
        
        }



    }
}
