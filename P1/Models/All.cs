using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class All
    {
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public IEnumerable<string> AllSkills { get; set; }
        public string? Skill { get; set; }
        public string? SKillTwo { get; set; }
        public string? SKillThree { get; set; }
        public string? City { get; set; }
        public string? InstuiteName { get; set; }
        public string? CompanyName { get; set; }

        public override string ToString()
        {
            int count = AllSkills.Count();
            switch (count)
            {
                case 1:
                    Skill = AllSkills.ElementAt(0);
                    break;
                case 2:
                    Skill = AllSkills.ElementAt(0);
                    SKillTwo = AllSkills.ElementAt(1);
                    break;
                case 3:
                    Skill = AllSkills.ElementAt(0);
                    SKillTwo = AllSkills.ElementAt(1);
                    SKillThree = AllSkills.ElementAt(2);
                    break;
                default:
                    break;
            }
            return $@"
Name            -   {Name} 
Age             -   {Age} 
Gender          -   {Gender} 
Primary Skill   -   {Skill} 
Secondary Skill -   {SKillTwo} 
Secondary Skill -   {SKillThree} 
City            -   {City} 
Instute Name    -   {InstuiteName} 
Comapny Name    -   {CompanyName}";
        }
    }
}
