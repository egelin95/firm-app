using firm_app;
using Microsoft.EntityFrameworkCore;

public class FirmDbContext: DbContext {
     public FirmDbContext(DbContextOptions<FirmDbContext> options)
            : base(options) { }

     public DbSet<Hint> Hints { get; set; }
     public DbSet<AccessLevel> AccessLevels { get; set; }
     public DbSet<BorrowedItem> BorrowedItems { get; set; }
     public DbSet<BranchOffice> BranchOffices { get; set; }
     public DbSet<Company> Companies { get; set; }
     public DbSet<Department> Departments { get; set; }
     public DbSet<Employee> Employees { get; set; }
     public DbSet<EmployeeChild> EmployeeChildren { get; set; }
     public DbSet<HealthCheck> HealthChecks { get; set; }
     public DbSet<Vacation> Vacations { get; set; }
     public DbSet<Request> Requests { get; set; }
     public DbSet<WorkTime> WorkTimes { get; set; }
     public DbSet<JobTitle> JobTitles { get; set; }
} 
