using System.Numerics;
using System.Reflection;

namespace DataLayer
{
    public class UpdateDetails
    {
        public UpdateDetails() { }
        
        public int id { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string aboutme { get; set; }
        public string gender { get; set; }

        public override string ToString()
        {
            return @$"
    Fullname - {fullname}
    Gender - {gender}
    Phone - {phone}
    Website - {website}
    About me - {aboutme}";
        }
    }
}
