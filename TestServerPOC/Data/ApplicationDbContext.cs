using Microsoft.EntityFrameworkCore;
using TestServerInMemoryDbPOC.Data;

namespace TestServerPOC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}