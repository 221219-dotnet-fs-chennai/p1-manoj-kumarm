
namespace Models
{
    public class TrainerLocation
    {
        public TrainerLocation() { }    
        public int Id { get; set; }

        public string Zipcode { get; set; } = null!;

        public string? City { get; set; }

        public int Trainerlocationid { get; set; }

        public override string ToString()
        {
            return @$"
    City:      {City}
    ZipCode:   {Zipcode}
";
        }
    }
}
