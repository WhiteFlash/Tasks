using Microsoft.EntityFrameworkCore;
using Tasks.Core.Model;

namespace Tasks.DAL.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Status.Config());
            modelBuilder.ApplyConfiguration(new Note.Config());
        }
    }
}
