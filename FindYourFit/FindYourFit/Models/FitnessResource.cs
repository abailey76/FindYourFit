using System;

namespace FindYourFit.Models
{
    public class FitnessResource
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ContactEmail { get; set; }

        public FitnessResourceCategory Category { get; set; }

        public int CategoryId { get; set; }

        public int Id { get; set; }

        public FitnessResource(string name, string description, string contactEmail)
        {
            Name = name;
            Description = description;
            ContactEmail = contactEmail;
        }

        public FitnessResource()
        {
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is FitnessResource @fitnessresource &&
                   Id == @fitnessresource.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
