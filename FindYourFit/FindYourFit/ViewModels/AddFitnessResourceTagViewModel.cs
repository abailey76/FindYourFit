using System.Collections.Generic;
using FindYourFit.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FindYourFit.ViewModels
{
    public class AddFitnessResourceTagViewModel
    {

        public int FitnessResourceId { get; set; }
        public FitnessResource FitnessResource { get; set; }

        public List<SelectListItem> Tags { get; set; }

        public int TagId { get; set; }

        public AddFitnessResourceTagViewModel(FitnessResource theFitnessResource, List<Tag> possibleTags)
        {
            Tags = new List<SelectListItem>();

            foreach (var tag in possibleTags)
            {
                Tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.Name
                });
            }

            FitnessResource = theFitnessResource;
        }

        public AddFitnessResourceTagViewModel()
        {
        }
    }
}

