using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitCatZafrazy.Models;

namespace RecruitCatZafrazy.Pages.CompanyPages
{
    public class EditModel : PageModel
    {
        private readonly RecruitCatZafrazyContext _context;

        public EditModel(RecruitCatZafrazyContext context)
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
                .FirstOrDefaultAsync(c => c.CompanyId == id);

            if (company == null)
            {
                return NotFound();
            }

            Company = company;

            LoadDropDowns();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadDropDowns();
                return Page();
            }

            _context.Attach(Company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(Company.CompanyId))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private void LoadDropDowns()
        {
            ViewData["JobTitleId"] = new SelectList(
                _context.JobTitle,
                "JobTitleId",
                "JobTitleName",
                Company?.JobTitleId
            );

            ViewData["IndustryId"] = new SelectList(
                _context.Industry,
                "IndustryId",
                "IndustryName",
                Company?.IndustryId
            );
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(c => c.CompanyId == id);
        }
    }
}