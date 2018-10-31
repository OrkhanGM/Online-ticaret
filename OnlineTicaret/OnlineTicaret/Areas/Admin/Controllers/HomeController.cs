using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineTicaret.Data;
using OnlineTicaret.Data.Interfaces;
using OnlineTicaret.Data.Models;
using OnlineTicaret.Data.Repository;
using OnlineTicaret.Data.ViewModels;

namespace OnlineTicaret.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public HomeController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View(_productRepository.Products.ToList());
        }

        public IActionResult Edit(int? id)
        {
            var product = _productRepository.Products.FirstOrDefault(p => p.ProductId == id);

            if(product == null)
            {
                return NotFound("product not found");
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.UpdateProduct(product);

            }

            return View(product);
        }

        [HttpGet]
        public ActionResult GetCategories()
        {
            var categs = _categoryRepository.Categories.Select(x => new CategoRyViewModel { Id = x.CategoryId, Name = x.CategoryName }).ToList();
            return Json(categs);
        }
    }
}