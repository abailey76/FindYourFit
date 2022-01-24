using FindYourFit.Data;
using FindYourFit.Models;
using FindYourFit.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;



namespace FindYourFit.Controllers
{
    [Authorize]
    public class ServiceProvidersController : Controller
    {

        private ApplicationDbContext context;

        public ServiceProvidersController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        [AllowAnonymous]

        public IActionResult Index()
        {
            List<ServiceProvider> serviceProviders = context.ServiceProviders
                .Include(e => e.Category)
                .ToList();

            return View(serviceProviders);
        }

        public IActionResult Add()
        {
            List<EventCategory> categories = context.EventCategories.ToList();
            AddServiceProviderViewModel addServiceProviderViewModel = new AddServiceProviderViewModel(categories);

            return View(addServiceProviderViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddServiceProviderViewModel addServiceProviderViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory theCategory = context.Categories.Find(addServiceProviderViewModel.CategoryId);
                ServiceProvider newServiceProvider = new ServiceProvider
                {
                    Name = addServiceProviderViewModel.Name,
                    Description = addServiceProviderViewModel.Description,
                    ContactEmail = addServiceProviderViewModel.ContactEmail,
                    Category = theCategory
                };

                context.ServiceProviders.Add(newServiceProvider);
                context.SaveChanges();

                return Redirect("/ServiceProviders");
            }

            return View(addServiceProviderViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = context.ServiceProviders.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] serviceProviderIds)
        {
            foreach (int serviceProviderId in serviceProviderIds)
            {
                ServiceProvider theServiceProvider = context.ServiceProviders.Find(serviceProviderId);
                context.ServiceProviders.Remove(theServiceProvider);
            }

            context.SaveChanges();

            return Redirect("/ServiceProviders");
        }

        public IActionResult Detail(int id)
        {
            ServiceProvider theServiceProvider = context.ServiceProviders
                .Include(e => e.Category)
                .Single(e => e.Id == id);

            List<EventTag> eventTags = context.EventTags
                .Where(et => et.EventId == id)
                .Include(et => et.Tag)
                .ToList();

            ServiceProviderDetailViewModel viewModel = new ServiceProviderDetailViewModel(theServiceProvider, eventTags);
            return View(viewModel);
        }
    }
}

