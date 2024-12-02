using iasalesmk.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace iasalesmk.infrastructure.Data;

public class ApplicationDbContext : DbContext  // Debe heredar de DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
