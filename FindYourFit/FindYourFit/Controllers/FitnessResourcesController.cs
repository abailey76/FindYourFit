using FindYourFit.Data;
using FindYourFit.Models;
using FindYourFit.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindYourFit.Controllers
{
    [Authorize]
    public class FitnessResourcesController : Controller
    {

        private ApplicationDbContext context;

        public FitnessResourcesController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        [AllowAnonymous]
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<FitnessResource> fitnessResources = context.FitnessResources
                .Include(e => e.Category)
                .ToList();

            return View(fitnessResources);
        }

        public IActionResult Add()
        {
            List<EventCategory> eventcategories = context.EventCategories.ToList();
            AddFitnessResourceViewModel addFitnessResourceViewModel = new AddFitnessResourceViewModel(eventcategories);

            return View(addFitnessResourceViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddFitnessResourceViewModel addFitnessResourceViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory theCategory = context.Categories.Find(addFitnessResourceViewModel.CategoryId);
                FitnessResource newFitnessResource = new FitnessResource
                {
                    Name = addFitnessResourceViewModel.Name,
                    Description = addFitnessResourceViewModel.Description,
                    //ContactEmail = addFitnessResourceViewModel.ContactEmail,
                    Category = theCategory
                };

                context.FitnessResources.Add(newFitnessResource);
                context.SaveChanges();

                return Redirect("/FitnessResources");
            }

            return View(addFitnessResourceViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = context.FitnessResources.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] fitnessResourceIds)
        {
            foreach (int fitnessResourceId in fitnessResourceIds)
            {
                FitnessResource theFitnessResource = context.FitnessResources.Find(fitnessResourceId);
                context.FitnessResources.Remove(theFitnessResource);
            }

            context.SaveChanges();

            return Redirect("/FitnessResources");
        }

        public IActionResult Detail(int id)
        {
            FitnessResource theFitnessResource = context.FitnessResources
               .Include(e => e.Category)
               .Single(e => e.Id == id);

            List<EventTag> eventTags = context.EventTags
                .Where(et => et.EventId == id)
                .Include(et => et.Tag)
                .ToList();

            FitnessResourceDetailViewModel viewModel = new FitnessResourceDetailViewModel(theFitnessResource, eventTags);
            return View(viewModel);
        }
    }
}

