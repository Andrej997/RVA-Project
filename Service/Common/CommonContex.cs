using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CommonContex : DbContext
    {
        public DbSet<Trener> Trener { get; set; }
        public DbSet<Vezbac> Vezbac { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Trening> Trening { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-H20J9R7; Database=RVA; Trusted_Connection=True; MultipleActiveResultSets=True;");
        }
    }
}
