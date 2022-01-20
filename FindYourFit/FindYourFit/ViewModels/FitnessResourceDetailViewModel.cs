using System.Collections.Generic;
using FindYourFit.Models;

namespace FindYourFit.ViewModels
{
    public class FitnessResourceDetailViewModel
    {
        public int FitnessResourceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string CategoryName { get; set; }
        public string TagText { get; set; }

        public FitnessResourceDetailViewModel(FitnessResource theFitnessResource, List<EventTag> eventTags)
        {
            FitnessResourceId = theFitnessResource.Id;
            Name = theFitnessResource.Name;
            Description = theFitnessResource.Description;
            ContactEmail = theFitnessResource.ContactEmail;
            CategoryName = theFitnessResource.Category.Name;

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
