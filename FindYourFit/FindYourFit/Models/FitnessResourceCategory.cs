using System.Collections.Generic;

namespace FindYourFit.Models
{
    public class FitnessResourceCategory
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public List<FitnessResource> fitnessresources { get; set; }

        public FitnessResourceCategory(string name)
        {
            Name = name;
        }

        public FitnessResourceCategory()
        {
        }
    }
}
