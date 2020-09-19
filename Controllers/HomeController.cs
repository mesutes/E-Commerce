using E_Commerce.Interfaces;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        IProductRepository _ProductRepository;
        public HomeController(IProductRepository _ProductRepository) 
        {
            this._ProductRepository = _ProductRepository;

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

        
    }
}
