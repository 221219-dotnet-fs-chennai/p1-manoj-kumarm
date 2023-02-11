
using System.Numerics;
using System.Reflection;

namespace Models
{
    public class TrainerEducation
    {
        public TrainerEducation() { }
        public int Id { get; set; }

        public string? Institute { get; set; }

        public string? Degreename { get; set; }

        public string? Gpa { get; set; }

        public string? Startdate { get; set; }

        public string? Enddate { get; set; }

        public int Trainereducationid { get; set; }

        public override string ToString()
        {
            return @$"
    Institute:      {Institute}
    Degree:         {Degreename}
    Gpa:            {Gpa}
    Start year:     {Startdate}
    End year:       {Enddate}
";
        }
    }
}
