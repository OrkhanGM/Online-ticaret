using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineTicaret.Data;
using OnlineTicaret.Data.Interfaces;
using OnlineTicaret.Data.Models;
using OnlineTicaret.Data.ViewModels;


namespace OnlineTicaret.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public int PageNumber { get; private set; }

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredProducts = _productRepository.PreferredProducts
            };
            return View(homeViewModel);
        }

        public IActionResult Search(string Name, int page = 0)
        {
            int PageNumber = page == 0 ? 1 : page;
            List<Product> products = _productRepository.Products.Where(x => x.Name.ToLower().Contains(Name.ToLower())).ToList().Skip(6 * (PageNumber - 1)).Take(6).ToList();
            ViewBag.SearchWord = Name;
            return View(products);

        }

        public IActionResult BigSize(int productId)
        {

            Product product = _productRepository.GetProductById(productId);
            return View(product);

        }

       

       

    }
};