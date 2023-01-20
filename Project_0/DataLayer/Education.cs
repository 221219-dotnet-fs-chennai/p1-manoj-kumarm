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
        public Education(string institute, string degree, string gpa, string startDate, string endDate) {
            this.institute= institute;
            this.degree= degree;
            this.gpa= gpa;  
            this.startDate= startDate;
            this.endDate= endDate;
        }  
        public string institute { get; set; }
        public string degree { get; set; }
        public string gpa { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

        public override string ToString()
        {
            return $"{institute} {degree} {gpa} {startDate} {endDate}";
        }

    }
}
