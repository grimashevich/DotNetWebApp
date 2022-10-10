using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Data;

public class EmployeeServiceDbContext : DbContext
{
    public DbSet<EmployeeType> EmployeeTypes { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountSession> Sessions { get; set; }

    public EmployeeServiceDbContext(DbContextOptions options) : base(options)
    {

    }
}