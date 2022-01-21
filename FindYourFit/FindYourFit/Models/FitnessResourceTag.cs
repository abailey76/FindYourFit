namespace FindYourFit.Models
{
    public class FitnessResourceTag
    {
        public int FitnessResourceId { get; set; }
        public FitnessResource FitnessResource { get; set; }

        public int FitnessResourceTagId { get; set; }
        public Tag Tag { get; set; }

        public FitnessResourceTag()
        {
        }
    }
}
