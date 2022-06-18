using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTask.Models
{
    public class LuftBornContext : DbContext
    {
        public LuftBornContext()
        {
        }

        public LuftBornContext(DbContextOptions<LuftBornContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Employee> Employee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=SystemConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
