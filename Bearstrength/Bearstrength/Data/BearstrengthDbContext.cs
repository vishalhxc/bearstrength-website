using Bearstrength.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bearstrength.Data
{
    public class BearstrengthDbContext : IdentityDbContext<BearstrengthUser>
    {
        /// <summary>
        /// Database context used for CRUD functions.
        /// </summary>
        /// <param name="options"></param>
        public BearstrengthDbContext(DbContextOptions<BearstrengthDbContext> options) : base(options)
        {
        }

        //Models with their associated database table names
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Routine> Routines { get; set; }
    }
}
