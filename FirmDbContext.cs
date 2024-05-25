using Microsoft.EntityFrameworkCore;

public class FirmDbContext: DbContext {
     public FirmDbContext(DbContextOptions<FirmDbContext> options)
            : base(options) { }
} 
