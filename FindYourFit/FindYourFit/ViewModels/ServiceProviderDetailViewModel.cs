using FindYourFit.Models;
using System.Collections.Generic;

namespace FindYourFit.ViewModels
{
    public class ServiceProviderDetailViewModel
    {
        public int ServiceProviderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string CategoryName { get; set; }
        public string TagText { get; set; }

        public ServiceProviderDetailViewModel(ServiceProvider theServiceProvider, List<EventTag> eventTags)
        {
            ServiceProviderId = theServiceProvider.Id;
            Name = theServiceProvider.Name;
            Description = theServiceProvider.Description;

            CategoryName = theServiceProvider.Category.Name;

            TagText = "";

            for (var i = 0; i < eventTags.Count; i++)
            {
                TagText += "#" + eventTags[i].Tag.Name;

                if (i < eventTags.Count - 1)
                {
                    TagText += ", ";
                }
            }
        }
    }
}
