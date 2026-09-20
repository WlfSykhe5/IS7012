using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatZafrazy.Models;

namespace RecruitCatZafrazy.Pages.CompanyPages
{
    public class DeleteModel : PageModel
    {
        private readonly RecruitCatZafrazyContext _context;

        public DeleteModel(RecruitCatZafrazyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Company Company { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .Include(c => c.JobTitle)
                .Include(c => c.Industry)
                .FirstOrDefaultAsync(c => c.CompanyId == id);

            if (company == null)
            {
                return NotFound();
            }

            Company = company;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FindAsync(id);

            if (company != null)
            {
                _context.Company.Remove(company);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}