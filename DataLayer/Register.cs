using System.ComponentModel.DataAnnotations;// used for "required"
namespace DataLayer
{
    public class Register
    {
        public Register() { }
        
        public Register(string email) {
            this.email = email; 
        }
        public Register(string email, string password, int userid) {
            this.email = email;
            this.password = password;
            this.userid = userid;   
        }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int userid { get; set; }

        public override string ToString()
        {
            return $"{email} {password} {userid}";
        }
    }
   
}
