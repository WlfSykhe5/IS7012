using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatZafrazy.Models;

namespace RecruitCatZafrazy.Pages.JobTitlePages;

public class DetailsModel : PageModel
{
    private readonly RecruitCatZafrazyContext _context;
    public DetailsModel(RecruitCatZafrazyContext context)
    {
        _context = context;
    }

    public JobTitle JobTitle { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var jobtitle = await _context.JobTitle.FirstOrDefaultAsync(m => m.JobTitleId == id);
        if (jobtitle is null)
        {
            return NotFound();
        }
        else
        {
            JobTitle = jobtitle;
        }

        return Page();
    }
}
