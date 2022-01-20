using System.Collections.Generic;
using System.Linq;
using FindYourFit.Data;
using FindYourFit.Models;
using Microsoft.AspNetCore.Mvc;
using FindYourFit.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindYourFit.Controllers
{
    public class FitnessResourceCategoryController : Controller
    {
        private ApplicationDbContext context;

        public FitnessResourceCategoryController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<FitnessResourceCategory> categories = context.FitnessResourceCategories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddFitnessResourceCategoryViewModel addFitnessResourceCategoryViewModel = new AddFitnessResourceCategoryViewModel();
            return View(addFitnessResourceCategoryViewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreateFitnessResourceCategoryForm(AddFitnessResourceCategoryViewModel addFitnessResourceCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                FitnessResourceCategory newCategory = new FitnessResourceCategory
                {
                    Name = addFitnessResourceCategoryViewModel.Name
                };

                context.FitnessResourceCategories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/FitnessResourceCategory");
            }

            return View("Create", addFitnessResourceCategoryViewModel);
        }
    }
}
