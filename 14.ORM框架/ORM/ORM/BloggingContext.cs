using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zack.EFCore.Batch.Oracle;

namespace ORM
{
    public class BloggingContext : DbContext
    {
        public DbSet<Equipment> EQUIPMENT { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BloggingContext()
        {
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.6.1.27)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User ID=NetStudy;Password=NetStudy;Max Pool Size=1000;");
            options.UseBatchEF_Oracle();
        }
    }
}
