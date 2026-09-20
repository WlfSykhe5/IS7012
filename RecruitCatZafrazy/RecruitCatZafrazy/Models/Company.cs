using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatZafrazy.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; } = string.Empty;

        [DisplayName("Minimum Asking Salary (USD)")]
        [DataType(DataType.Currency)]
        [Range(0, 10000000)]
        public decimal MinimumSalary { get; set; }

        [DisplayName("Maximum Asking Salary (USD)")]
        [DataType(DataType.Currency)]
        [Range(0, 10000000)]
        public decimal MaximumSalary { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Required]
        [StringLength(250)]
        [DisplayName("Company Address")]
        public string Location { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        [Phone]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [DisplayName("Incorporation Date")]
        [DataType(DataType.Date)]
        public DateTime IncorporationDate { get; set; }

        [DisplayName("Job Title")]
        public int JobTitleId { get; set; }

        public JobTitle? JobTitle { get; set; }

        [DisplayName("Industry")]
        public int IndustryId { get; set; }

        public Industry? Industry { get; set; }

        public List<Candidate> Candidates { get; set; } = new List<Candidate>();
    }
}