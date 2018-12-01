using Microsoft.EntityFrameworkCore;

namespace Bearstrength.Models
{
    public class BearstrengthDbContext : DbContext
    {
        public BearstrengthDbContext(DbContextOptions<BearstrengthDbContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
