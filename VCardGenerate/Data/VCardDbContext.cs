using Microsoft.EntityFrameworkCore;
using VCardGenerate.Models;

namespace VCardGenerate.Data;

public class VCardDbContext : DbContext
{
    public DbSet<VCard> VCards { get; set; }

    public VCardDbContext(DbContextOptions<VCardDbContext> options) : base(options)
    {
    }
}
