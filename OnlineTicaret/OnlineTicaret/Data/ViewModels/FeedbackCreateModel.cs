using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTicaret.Data.ViewModels
{
    public class FeedbackCreateModel
    {
        public string UserName { get; set; }    
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
