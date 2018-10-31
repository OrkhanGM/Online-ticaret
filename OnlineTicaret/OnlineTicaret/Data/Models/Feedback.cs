using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTicaret.Data.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        [Required(ErrorMessage = "Please enter your  Name")]
        [StringLength(20, MinimumLength = 4)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
           ErrorMessage = "The email address is not entered in a correct format")]
        [Required(ErrorMessage = "Please enter your  Email")]
        [StringLength(20, MinimumLength = 4)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your  Message")]
        [StringLength(100, MinimumLength = 4)]
        public string Message { get; set; }


        public DateTime Date { get; set; }  
    }
}
