using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp3.Shared
{
    public partial class SQLDBContext : DbContext
    {
        private readonly string _conexionString = "Server=LAPTOP-Q1PBGT9D\\MSSQLSERVER2;Database=Renta;Trusted_Connection=true;MultipleActiveResultSets=true; Encrypt=false;";
        public SQLDBContext()
        {
        }

        public SQLDBContext(DbContextOptions<SQLDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Socios> Socios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_conexionString);
            }
            base.OnConfiguring(optionsBuilder);
        }


    }
}
