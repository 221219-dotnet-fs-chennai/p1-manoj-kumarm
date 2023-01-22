using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Skills
    {
        public Skills() { } 
        public Skills(string skillName) { 
            this.skillName = skillName; 
        }
        public string skillName { get; set; }
        public int trainerskillid { get; set; }

        public override string ToString()
        {
            return $"\nSkill Name: {skillName}"; 
        }
    }
}
