using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitCatZafrazy.Models;

namespace RecruitCatZafrazy.Pages.CandidatePages
{
    public class EditModel : PageModel
    {
        private readonly RecruitCatZafrazyContext _context;

        public EditModel(RecruitCatZafrazyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Candidate Candidate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidate
                .FirstOrDefaultAsync(c => c.CandidateId == id);

            if (candidate == null)
            {
                return NotFound();
            }

            Candidate = candidate;

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

            _context.Attach(Candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(Candidate.CandidateId))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private void LoadDropDowns()
        {
            ViewData["CompanyId"] = new SelectList(
                _context.Company,
                "CompanyId",
                "CompanyName",
                Candidate?.CompanyId
            );

            ViewData["JobTitleId"] = new SelectList(
                _context.JobTitle,
                "JobTitleId",
                "JobTitleName",
                Candidate?.JobTitleId
            );

            ViewData["IndustryId"] = new SelectList(
                _context.Industry,
                "IndustryId",
                "IndustryName",
                Candidate?.IndustryId
            );
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidate.Any(c => c.CandidateId == id);
        }
    }
}