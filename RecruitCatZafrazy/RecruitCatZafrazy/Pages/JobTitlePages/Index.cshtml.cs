using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatZafrazy.Models;

namespace RecruitCatZafrazy.Pages.JobTitlePages;

public class IndexModel : PageModel
{
    private readonly RecruitCatZafrazyContext _context;

    public IndexModel(RecruitCatZafrazyContext context)
    {
        _context = context;
    }

    public IList<JobTitle> JobTitle { get; set; } = default!;

    public async Task OnGetAsync()
    {
        JobTitle = await _context.JobTitle.ToListAsync();
    }
}
