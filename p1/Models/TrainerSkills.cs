using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TrainerSkills
    {
        public int Id { get; set; }

        public string? Skill { get; set; }

        public int Trainerskillid { get; set; }

        public override string ToString()
        {
            return @$"
    Skill Name:       {Skill}
";
        }
    }
}
