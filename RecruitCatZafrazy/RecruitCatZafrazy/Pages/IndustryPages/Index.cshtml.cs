using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatZafrazy.Models;

namespace RecruitCatZafrazy.Pages.IndustryPages;

public class IndexModel : PageModel
{
    private readonly RecruitCatZafrazyContext _context;

    public IndexModel(RecruitCatZafrazyContext context)
    {
        _context = context;
    }

    public IList<Industry> Industry { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Industry = await _context.Industry.ToListAsync();
    }
}
