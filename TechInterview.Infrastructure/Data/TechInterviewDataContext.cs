using Microsoft.EntityFrameworkCore;
using TechInterview.Core.Entities;

namespace TechInterview.Infrastructure.Data
{
    public class TechInterviewDataContext : DbContext
    {
        public TechInterviewDataContext(DbContextOptions<TechInterviewDataContext> options)
            : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
    }
}