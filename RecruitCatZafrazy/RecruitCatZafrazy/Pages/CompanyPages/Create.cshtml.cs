using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitCatZafrazy.Models;

namespace RecruitCatZafrazy.Pages.CompanyPages
{
    public class CreateModel : PageModel
    {
        private readonly RecruitCatZafrazyContext _context;

        public CreateModel(RecruitCatZafrazyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Company Company { get; set; } = new Company();

        public IActionResult OnGet()
        {
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

            _context.Company.Add(Company);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private void LoadDropDowns()
        {
            ViewData["JobTitleId"] = new SelectList(
                _context.JobTitle,
                "JobTitleId",
                "JobTitleName"
            );

            ViewData["IndustryId"] = new SelectList(
                _context.Industry,
                "IndustryId",
                "IndustryName"
            );
        }
    }
}