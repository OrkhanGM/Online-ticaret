using OnlineTicaret.Data.Interfaces;
using OnlineTicaret.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTicaret.Data.Repository
{
    public class FeedbackRepocitory : IFeedbackRepository
    {
        private readonly AppDbContext _appDbContext;
        public FeedbackRepocitory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Create(Feedback feedback)
        {
            _appDbContext.Add(feedback);
            _appDbContext.SaveChanges();
        }
    }
}
