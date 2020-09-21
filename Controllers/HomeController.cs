using E_Commerce.Entities;
using E_Commerce.Interfaces;
using E_Commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        IProductRepository _ProductRepository;
        public HomeController(IProductRepository _ProductRepository, SignInManager<AppUser> _signInManager) 
        {
            this._ProductRepository = _ProductRepository;
            this._signInManager = _signInManager;

        }

        public IActionResult Index()
        {
            return View(_ProductRepository.GetAll());
        }

        public IActionResult ProductDetail(int Id) 
        {
            return View(_ProductRepository.GetEntity(Id));
        }
     

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AdminLogin()
        {
            return View(new AdminLoginModel());
        }

        [HttpPost]
        public IActionResult AdminLogin(AdminLoginModel model)
        {
            if (ModelState.IsValid) 
            {
                var signinresult = _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RemindMe, false).Result;

                if (signinresult.Succeeded) 
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }

                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");

            }
            return View(model);
           
        }

        


    }
}
