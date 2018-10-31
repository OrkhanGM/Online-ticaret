using OnlineTicaret.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTicaret.Data.Interfaces
{
    public interface  IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> PreferredProducts { get; }
        Product GetProductById(int productId);
        void UpdateProduct(Product model);
    }
}
