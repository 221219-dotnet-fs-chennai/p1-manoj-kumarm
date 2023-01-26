using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Education
    {
        public Education() { }  
        
        public string institute { get; set; }
        public string degree { get; set; }
        public string gpa { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

        public override string ToString()
        {
            return $"\nInstitute Name: {institute}\nDegree: {degree}\nGPA: {gpa}\nStart Date: {startDate}\nEnd Date: {endDate}\n";
        }

    }
}
