using Bearstrength.Data;
using Bearstrength.Models;
using Bearstrength.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bearstrength.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IBearstrengthRepository _repository;

        public ActivityController(IBearstrengthRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var activities = _repository.GetAllActivities();
            return View(activities);
        }

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
        public ActionResult CreateActivity(ActivityFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _repository.GetAllCategories();
                return View("Create", viewModel);
            }

            var activity = new Activity
            {
                CategoryId = viewModel.CategoryId,
                Name = viewModel.Name
            };

            _repository.AddActivity(activity);
            _repository.SaveAll();
            return RedirectToAction("Index", "Activity");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Activity/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Activity/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Activity/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Activity/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}