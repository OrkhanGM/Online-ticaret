using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineTicaret.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter your  Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your  ShortDescription")]
        [StringLength(150)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Please enter your  LongDescription")]
        [StringLength(250)]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Please enter your Price")]
        [Display(Name = "Price")]
        
        public decimal Price { get; set; }


        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsPreferredProduct { get; set; }
        public bool InStock { get; set; }
        public bool Approved { get; set; } = false;
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
