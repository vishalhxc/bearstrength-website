using Bearstrength.Models;
using Bearstrength.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bearstrength.Controllers
{
    public class ActivityController : Controller
    {
        private readonly BearstrengthDbContext _context;

        public ActivityController(BearstrengthDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var activities = _context.Activities
                .OrderBy(a => a.Name)
                .Include(a => a.Category);
            return View(activities);
        }

        public ActionResult Create()
        {
            var viewModel = new ActivityFormViewModel
            {
                Categories = _context.Categories.ToList()
            };

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateActivity(ActivityFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("Create", viewModel);
            }

            var activity = new Activity
            {
                CategoryId = viewModel.CategoryId,
                Name = viewModel.Name
            };

            _context.Activities.Add(activity);
            _context.SaveChanges();
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