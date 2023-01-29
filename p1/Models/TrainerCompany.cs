
using System.Numerics;
using System.Reflection;

namespace Models
{
    public class TrainerCompany
    {
        public int Id { get; set; }

        public string? Companyname { get; set; }

        public string? Title { get; set; }

        public string? Startyear { get; set; }

        public string? Endyear { get; set; }

        public int Trainercompanyid { get; set; }

        public override string ToString()
        {
            return @$"
    Company name:      {Companyname}
    Title:             {Title}
    Start year:        {Startyear}
    End year:          {Endyear}
";
        }
    }
}
