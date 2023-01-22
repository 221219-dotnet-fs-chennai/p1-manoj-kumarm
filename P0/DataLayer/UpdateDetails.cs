using System.Numerics;
using System.Reflection;

namespace DataLayer
{
    public class UpdateDetails
    {
        public UpdateDetails() { }
        
        public string fullname { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string aboutme { get; set; }
        public string gender { get; set; }

        public override string ToString()
        {
            return $"\nFullname: {fullname}\nGender: {gender}\nPhone: {phone}\nWebsite: {website}\nAbout me: {aboutme}\n";
        }
    }
}
