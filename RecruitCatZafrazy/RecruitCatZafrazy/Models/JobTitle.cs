using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatZafrazy.Models
{
    public class JobTitle
    {
        public int JobTitleId { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Job Title")]
        public string JobTitleName { get; set; }

        [DisplayName("Minimum Salary (USD)")]
        [DataType(DataType.Currency)]
        [Range(0, 10000000)]
        public decimal MinimumSalary { get; set; }

        [DisplayName("Maximum Salary (USD)")]
        [DataType(DataType.Currency)]
        [Range(0, 10000000)]
        public decimal MaximumSalary { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Employment Type")]
        public string EmploymentType { get; set; }

        [DisplayName("Job Offer (USD)")]
        [DataType(DataType.Currency)]
        [Range(0, 10000000)]
        public decimal JobOffer { get; set; }

        public List<Candidate> Candidates { get; set; } = new List<Candidate>();

        public List<Company> Companies { get; set; } = new List<Company>();
    }
}