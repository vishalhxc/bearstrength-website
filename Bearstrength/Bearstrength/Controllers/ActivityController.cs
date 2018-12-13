using System.Threading.Tasks;
using Bearstrength.Data;
using Bearstrength.Models;
using Bearstrength.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bearstrength.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IBearstrengthRepository _repository;
        private readonly UserManager<BearstrengthUser> _userManager;

        public ActivityController(IBearstrengthRepository repository, UserManager<BearstrengthUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        [Authorize]
        public ActionResult Index()
        {
            var activities = _repository.GetAllActivities();
            return View(activities);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ActivityFormViewModel
            {
                Categories = _repository.GetAllCategories()
            };

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateActivity(ActivityFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _repository.GetAllCategories();
                return View("Create", viewModel);
            }

            var activity = new Activity
            {
                CategoryId = viewModel.CategoryId,
                Name = viewModel.Name,
                User = await _userManager.GetUserAsync(User)
            };

            _repository.AddActivity(activity);
            _repository.SaveAll();
            return RedirectToAction("Index", "Activity");
        }
    }
}