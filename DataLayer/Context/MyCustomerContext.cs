using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class MyCustomerContext : DbContext
{
    public MyCustomerContext(DbContextOptions options) : base(options)
    {

    }









    public DbSet<Customer> Customers { get; set; }
}
