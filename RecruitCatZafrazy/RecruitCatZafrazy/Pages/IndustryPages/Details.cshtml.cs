using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatZafrazy.Models;

namespace RecruitCatZafrazy.Pages.IndustryPages;

public class DetailsModel : PageModel
{
    private readonly RecruitCatZafrazyContext _context;
    public DetailsModel(RecruitCatZafrazyContext context)
    {
        _context = context;
    }

    public Industry Industry { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var industry = await _context.Industry.FirstOrDefaultAsync(m => m.IndustryId == id);
        if (industry is null)
        {
            return NotFound();
        }
        else
        {
            Industry = industry;
        }

        return Page();
    }
}
