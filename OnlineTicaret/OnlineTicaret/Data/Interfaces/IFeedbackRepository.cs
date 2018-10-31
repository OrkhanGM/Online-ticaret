using OnlineTicaret.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTicaret.Data.Interfaces
{
    public interface IFeedbackRepository
    {
        void Create(Feedback feedback);
    }
}
