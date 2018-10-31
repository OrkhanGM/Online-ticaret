using Microsoft.AspNetCore.Mvc;
using OnlineTicaret.Data.Interfaces;
using OnlineTicaret.Data.Models;
using OnlineTicaret.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PagedList;

namespace OnlineTicaret.Controllers
{
    public class ProductController:Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ViewResult List(string category, int page = 0)
        {
            string _category = category;
            int PageNumber = page == 0 ? 1 : page;
            IEnumerable<Product> products;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                products = _productRepository.Products.Where(x => x.Approved == true).Skip(6 * (PageNumber - 1)).Take(6).ToList();
                currentCategory = "All products";
            }
            
            else
            {
                if (string.Equals("Elektronika", _category, StringComparison.OrdinalIgnoreCase))
                    products = _productRepository.Products.Where(p => p.Category.CategoryName.Equals("Elektronika") && p.Approved == true).OrderBy(p => p.Name).Skip(6 * (PageNumber - 1)).Take(6).ToList();
                 else if (string.Equals("Şəxsi-Əşyalar", _category, StringComparison.OrdinalIgnoreCase))
                    products = _productRepository.Products.Where(p => p.Category.CategoryName.Equals("Şəxsi-Əşyalar") && p.Approved == true).OrderBy(p => p.Name).Skip(6 * (PageNumber - 1)).Take(6).ToList();
               else  if (string.Equals("Neqliyyat", _category, StringComparison.OrdinalIgnoreCase))
                    products = _productRepository.Products.Where(p => p.Category.CategoryName.Equals("Neqliyyat") && p.Approved == true).OrderBy(p => p.Name).Skip(6 * (PageNumber - 1)).Take(6).ToList();
                
                else

                products = _productRepository.Products.Where(p => p.Category.CategoryName.Equals("Dasinmaz-Emlak") && p.Approved == true).OrderBy(p => p.Name).Skip(6 * (PageNumber - 1)).Take(6).ToList();
                currentCategory = _category;
            }

            return View(new ProductListViewModel
            {
                Products = products,
                CurrentCategory = currentCategory
            });
        }


        
    }
}

    

