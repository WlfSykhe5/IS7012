using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatZafrazy.Models;

namespace RecruitCatZafrazy.Pages.CompanyPages
{
    public class IndexModel : PageModel
    {
        private readonly RecruitCatZafrazyContext _context;

        public IndexModel(RecruitCatZafrazyContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get; set; } = new List<Company>();

        public async Task OnGetAsync()
        {
            Company = await _context.Company
                .Include(c => c.Industry)
                .Include(c => c.JobTitle)
                .ToListAsync();
        }
    }
}