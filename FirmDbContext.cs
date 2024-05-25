using firm_app;
using Microsoft.EntityFrameworkCore;

public class FirmDbContext: DbContext {
     public FirmDbContext(DbContextOptions<FirmDbContext> options)
            : base(options) { }

     public DbSet<Hint> Hints { get; set; }
} 
