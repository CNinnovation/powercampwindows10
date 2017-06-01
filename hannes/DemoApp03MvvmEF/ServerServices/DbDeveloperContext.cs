using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerModels;

namespace ServerServices
{
    public class DbDeveloperContext : DbContext
    {
        public DbDeveloperContext(DbContextOptions<DbDeveloperContext> options ) : base( options )
        {
        }

        public DbSet< Developer > Developers { get; set; }
    }
}