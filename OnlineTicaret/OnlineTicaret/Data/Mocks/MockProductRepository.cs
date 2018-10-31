using OnlineTicaret.Data.Interfaces;
using OnlineTicaret.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTicaret.Data.Mocks
{
    public class MockProductRepository : IProductRepository
    {

        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Product> Products
        {
            get
            {
                return new List<Product>
                {
                    new Product {
                        Name = "Iphone x",
                        Price = 2100 , ShortDescription = "The most widely consumed alcohol",
                        LongDescription = "Beer is the world's oldest[1][2][3] and most widely consumed[4] alcoholic drink; it is the third most popular drink overall, after water and tea.[5] The production of beer is called brewing, which involves the fermentation of starches, mainly derived from cereal grains—most commonly malted barley, although wheat, maize (corn), and rice are widely used.[6] Most beer is flavoured with hops, which add bitterness and act as a natural preservative, though other flavourings such as herbs or fruit may occasionally be included. The fermentation process causes a natural carbonation effect, although this is often removed during processing, and replaced with forced carbonation.[7] Some of humanity's earliest known writings refer to the production and distribution of beer: the Code of Hammurabi included laws regulating beer and beer parlours.",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "/image/IphoneX.jpg",
                        InStock = true,
                        IsPreferredProduct = true,
                        ImageThumbnailUrl = "/image/IphoneX.jpg"
                    }

                };
            }
        }
        public IEnumerable<Product> PreferredProducts { get; }
        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product model)
        {
            throw new NotImplementedException();
        }
    }
}

