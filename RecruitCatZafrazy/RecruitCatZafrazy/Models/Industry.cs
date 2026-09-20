using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatZafrazy.Models
{
    public class Industry
    {
        public int IndustryId { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Industry Name")]
        public string IndustryName { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        [DisplayName("Industry Description")]
        public string Description { get; set; } = string.Empty;

        public List<Candidate> Candidates { get; set; } = new List<Candidate>();

        public List<Company> Companies { get; set; } = new List<Company>();
    }
}