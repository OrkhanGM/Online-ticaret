using Microsoft.EntityFrameworkCore;
using OnlineTicaret.Data.Interfaces;
using OnlineTicaret.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTicaret.Data.Repository
{
    public class ProductRepository :IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> Products => _appDbContext.Products.Include(c => c.Category);

        public IEnumerable<Product> PreferredProducts => _appDbContext.Products.Where(p => p.IsPreferredProduct).Include(c => c.Category);

        public Product GetProductById(int productId) => _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);

        public void UpdateProduct(Product model)
        {
            _appDbContext.Products.Update(model);
            var aff =_appDbContext.SaveChanges();
        }
    }
}
