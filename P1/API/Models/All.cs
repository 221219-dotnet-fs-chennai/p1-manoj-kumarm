using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class All
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? AboutMe { get; set; }
        public IEnumerable<Models.EditTrainerLocation> Location { get; set; }
        public IEnumerable<string> Skills { get; set; }
        public IEnumerable<Models.UpdateTrainerCompany> Companies { get; set; }
        public IEnumerable<Models.UpdateTrainerEducation> Education { get; set; }
    }
}
