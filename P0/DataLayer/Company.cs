namespace DataLayer
{
    public class Company
    {
        public Company() { }    
        public string companyname { get; set; }
        public string title { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }

        public override string ToString()
        {
            return $"\nCompany Name: {companyname}\nTitle: {title}\nStart Year: {startdate}\nEnd Year: {enddate}\n";
        }
    }
}
