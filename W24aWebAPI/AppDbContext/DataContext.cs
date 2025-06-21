using Microsoft.EntityFrameworkCore;
using W24aWebAPI.Models;

namespace W24aWebAPI.AppDbContext
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
    }
}
