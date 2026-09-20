using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatZafrazy.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;

        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Target Salary (USD)")]
        [DataType(DataType.Currency)]
        [Range(0, 10000000)]
        public decimal TargetSalary { get; set; }

        [Required]
        [StringLength(20)]
        [Phone]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Notice Period Required")]
        public bool NoticePeriodRequired { get; set; }

        [DisplayName("Notice Period Days")]
        [Range(0, 365)]
        public int? NoticePeriodDays { get; set; }

        [DisplayName("Company")]
        public int? CompanyId { get; set; }

        public Company? Company { get; set; }

        [DisplayName("Job Title")]
        public int JobTitleId { get; set; }

        public JobTitle? JobTitle { get; set; }

        [DisplayName("Industry")]
        public int IndustryId { get; set; }

        public Industry? Industry { get; set; }
    }
}