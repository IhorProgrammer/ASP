using Microsoft.EntityFrameworkCore;

namespace ASP.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Entities.User> User { get; set; }
        
        public DataContext(DbContextOptions options) : base(options) { }
    }
}
