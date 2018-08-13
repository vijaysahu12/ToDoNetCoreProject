
using Microsoft.EntityFrameworkCore;

namespace ToDo.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DatabaseContext()
        {

        }
        public DbSet<Database.Table.ToDo> ToDo { get; set; }
    }
}

