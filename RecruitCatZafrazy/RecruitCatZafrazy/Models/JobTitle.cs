namespace RecruitCatZafrazy.Models
{
    public class JobTitle
    {
        public int JobTitleId { get; set; }
        public string JobTitleName { get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        public string EmploymentType { get; set; }
        public decimal JobOffer { get; set; }
        public List<Candidate> Candidates { get; set; } = new List<Candidate>();
        public List<Company> Companies { get; set; } = new List<Company>();

    }


}
