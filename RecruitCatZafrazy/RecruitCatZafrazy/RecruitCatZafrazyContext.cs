using Microsoft.EntityFrameworkCore;
using RecruitCatZafrazy.Models;

public class RecruitCatZafrazyContext(
    DbContextOptions<RecruitCatZafrazyContext> options)
    : DbContext(options)
{
    public DbSet<Candidate> Candidate { get; set; } = default!;
    public DbSet<Company> Company { get; set; } = default!;
    public DbSet<Industry> Industry { get; set; } = default!;
    public DbSet<JobTitle> JobTitle { get; set; } = default!;
}