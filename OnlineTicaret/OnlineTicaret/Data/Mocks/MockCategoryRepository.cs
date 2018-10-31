using OnlineTicaret.Data.Interfaces;
using OnlineTicaret.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTicaret.Data.Mocks
{
    public class MockCategoryRepository: ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category {CategoryName = "Elektronika",Description="Butun Elektronika"},
                    new Category {CategoryName = "Dasinmaz Emlak",Description="Butun Dasinmaz Emlak"},
                    new Category {CategoryName = "Neqliyyat",Description="Butun Neqliyyat"},
                    new Category {CategoryName = "Şəxsi Əşyalar",Description="Butun Şəxsi Əşyalar"},
                   



                };
            }

        }
    }
}
