using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineTicaret.Data;
using OnlineTicaret.Data.Models;

namespace OnlineTicaret.Controllers
{
    public class AddProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _env;

        public AddProductController(AppDbContext context, IHostingEnvironment env )
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Index([Bind("Id, Name, Price, ShortDescription, LongDescription, CategoryId")] Product product, IFormFile Image)
        {
            if(ModelState.IsValid)
            {
                if (Image.Length > 0)
                {
                    string path = Path.Combine(_env.WebRootPath, "Images", Image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                        product.ImageThumbnailUrl = "/images/" + Image.FileName;
                    }
                }
                await _context.AddAsync(product);
                await _context.SaveChangesAsync();

                return RedirectToAction("Productcomplete");


            }

            


            return View();
        }

        public IActionResult Productcomplete()
        {
           
            return View();
        }


    }
}