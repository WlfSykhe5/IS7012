namespace RecruitCatZafrazy.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public decimal TargetSalary { get; set; }
        public DateTime? StartDate { get; set; }

        public string Email { get; set; }
        public bool NoticePeriodRequired { get; set; }
        public int? NoticePeriodDays { get; set; }

        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        public int JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; }

        public int IndustryId { get; set; }
        public Industry Industry { get; set; }
    }

}
