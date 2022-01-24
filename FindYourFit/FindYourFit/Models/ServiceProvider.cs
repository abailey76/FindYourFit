using System;

namespace FindYourFit.Models
{
    public class ServiceProvider
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ContactEmail { get; set; }

        public EventCategory Category { get; set; }

        public int CategoryId { get; set; }

        public int Id { get; set; }
        public EventCategory EventCategory { get; internal set; }

        public ServiceProvider()
        {

        }

        public ServiceProvider(string name, string description, string contactemail)
        {
            Name = name;
            Description = description;
            ContactEmail = contactemail;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is ServiceProvider @serviceprovider &&
                   Id == @serviceprovider.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
