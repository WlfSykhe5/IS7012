using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatZafrazy.Models;

namespace RecruitCatZafrazy.Pages.CandidatePages;

public class DetailsModel : PageModel
{
    private readonly RecruitCatZafrazyContext _context;

    public DetailsModel(RecruitCatZafrazyContext context)
    {
        _context = context;
    }

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
}