using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatZafrazy.Models;

namespace RecruitCatZafrazy.Pages.CandidatePages;

public class DeleteModel : PageModel
{
    private readonly RecruitCatZafrazyContext _context;

    public DeleteModel(RecruitCatZafrazyContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Candidate Candidate { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var candidate = await _context.Candidate
            .Include(c => c.Company)
            .Include(c => c.JobTitle)
            .Include(c => c.Industry)
            .FirstOrDefaultAsync(c => c.CandidateId == id);

        if (candidate is null)
        {
            return NotFound();
        }

        Candidate = candidate;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var candidate = await _context.Candidate.FindAsync(id);

        if (candidate != null)
        {
            _context.Candidate.Remove(candidate);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}