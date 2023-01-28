namespace Models
{
    public class TrainerDetail
    {
        public TrainerDetail() { }

        public string? Fullname { get; set; }

        public string? Phone { get; set; }

        public string? Website { get; set; }

        public string? Aboutme { get; set; }

        public string? Gender { get; set; }

        public string? Age { get; set; }

        public int Trainerid { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public override string ToString()
        {
            return @$"
    Email:      {Email}
    Name:       {Fullname}
    Phone:      {Phone}
    Gender:     {Gender}
    Age:        {Age}
    Website:    {Website}
";
        }
    }
}
