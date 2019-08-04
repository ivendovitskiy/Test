using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForm.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test;Trusted_Connection=True;");
        }

        public DbSet<Device> Devices { get; set; }
    }
}
//https://github.com/ivendovitsky/Test/invitations