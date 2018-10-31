using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineTicaret.Data.Interfaces;
using OnlineTicaret.Data.Models;
using OnlineTicaret.Data.ViewModels;

namespace OnlineTicaret.Controllers
{
    public class ContactController : Controller
    {
        // GET: /<controller>/
        private readonly IFeedbackRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;
        public ContactController(IFeedbackRepository repository, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(new FeedbackCreateModel());
        }

        [HttpPost]
        public IActionResult AddFeedback(FeedbackCreateModel model)
        {
            Feedback feedback = new Feedback
            {
                Date = DateTime.Now,
                Email = model.Email,
                Message = model.Message,
                Name = model.Name
            };
            if (model.UserName != null)
            {
                feedback.UserId = _userManager.FindByNameAsync(model.UserName).Result.Id;
                feedback.Email = _userManager.FindByNameAsync(model.UserName).Result.Email;
            }
            _repository.Create(feedback);
            return RedirectToAction("MessageComplete");
        }

        public IActionResult MessageComplete()
        {

            return View();
        }
    }
}