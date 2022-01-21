using System;

namespace FindYourFit.Models
{
    public class FitnessResource
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ContactEmail { get; set; }

        public EventCategory Category { get; set; }

        public int CategoryId { get; set; }

        public int Id { get; set; }
        public EventCategory EventCategory { get; internal set; }

        public FitnessResource()
        {
        }

        public FitnessResource(string name, string description)
        {
            Name = name;
            Description = description;
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
