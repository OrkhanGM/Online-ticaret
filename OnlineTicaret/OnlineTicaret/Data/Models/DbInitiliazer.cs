using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTicaret.Data.Models
{
    public class DbInitiliazer
    {
        public static void Seed(IServiceProvider applicationBuilder)
        {
            AppDbContext context =
                applicationBuilder.GetRequiredService<AppDbContext>();


            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Products.Any())
            {
                context.AddRange
                (
                    new Product
                    {
                        Name = "Iphone 7",
                        Price = 2100,
                        ShortDescription = "The best smartphone in the world",
                        LongDescription = "	Type	LED-backlit IPS LCD, capacitive touchscreen, 16M colors, Size	4.7 inches, 60.9 cm2 (~65.6% screen-to-body ratio)",
                        Category = Categories["Elektronika"],
                        ImageUrl = "/image/IphoneX.jpg",
                        InStock = true,
                        IsPreferredProduct = true,
                        ImageThumbnailUrl = "/image/Iphone7.jpg"
                    }
                    
                );
            }

            context.SaveChanges();
        }

        internal static void Seed(AppDbContext appDbContext)
        {
            throw new NotImplementedException();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category {CategoryName = "Elektronika",Description="Butun-Elektronika"},
                        new Category {CategoryName = "Dasinmaz-Emlak",Description="Butun-Dasinmaz-Emlak"},
                        new Category {CategoryName = "Neqliyyat",Description="Butun-Neqliyyat"},
                        new Category {CategoryName = "Şəxsi-Əşyalar",Description="Butun-Şəxsi-Əşyalar"},
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}

