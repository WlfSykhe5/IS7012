using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatZafrazy.Models;

namespace RecruitCatZafrazy.Pages.CompanyPages
{
    public class DetailsModel : PageModel
    {
        private readonly RecruitCatZafrazyContext _context;

        public DetailsModel(RecruitCatZafrazyContext context)
        {
            _context = context;
        }

        public Company Company { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .Include(c => c.Industry)
                .Include(c => c.JobTitle)
                .Include(c => c.Candidates)
                .FirstOrDefaultAsync(c => c.CompanyId == id);

            if (company == null)
            {
                return NotFound();
            }

            Company = company;

            return Page();
        }
    }
}