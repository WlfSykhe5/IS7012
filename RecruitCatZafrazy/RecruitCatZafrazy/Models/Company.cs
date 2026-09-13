namespace RecruitCatZafrazy.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        public DateTime? StartDate { get; set; }
        public string Location { get; set; }

        public DateTime IncorporationDate { get; set; }

        public int JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; }

        public List<Candidate> Candidates { get; set; }

        public int IndustryId { get; set; }
        public Industry Industry { get; set; }
    }

}
