using Microsoft.EntityFrameworkCore;

namespace MVCapp.Models
{
    public class EmpDbContext : DbContext
    {
        public DbSet<Emp> emps { get; set; }

        public EmpDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
