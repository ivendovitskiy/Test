using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=WIN-INFMG8OPRNS;Database=Test;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDb;Database=Test;Trusted_Connection=True;");
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
    }
}