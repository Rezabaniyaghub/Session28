using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class AppDbContext:DbContext 
    {
        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
                
        }
        public DbSet<School> Schools { get; set; }
    }
}
