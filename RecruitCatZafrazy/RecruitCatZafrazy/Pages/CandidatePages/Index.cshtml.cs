using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatZafrazy.Models;

namespace RecruitCatZafrazy.Pages.CandidatePages
{
    public class IndexModel : PageModel
    {
        private readonly RecruitCatZafrazyContext _context;

        public IndexModel(RecruitCatZafrazyContext context)
        {
            _context = context;
        }

        public IList<Candidate> Candidate { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Candidate = await _context.Candidate
                .Include(c => c.Company)
                .Include(c => c.JobTitle)
                .Include(c => c.Industry)
                .ToListAsync();
        }
    }
}