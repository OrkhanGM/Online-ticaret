using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTicaret.Data.ViewModels
{
    public class LoginViewModel
    {
       
        [Required(ErrorMessage ="Username is reguired") , MaxLength(256)]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is reguired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        

        public string ReturnUrl { get; set; }

    }
}
