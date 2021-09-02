using Microsoft.EntityFrameworkCore;
using Tasks.Core.Model;
using Tasks.DAL.Data.Interfaces;

namespace Tasks.DAL.Data
{ 
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Core.Model.Tasks> Tasks { get; set; }
        public DbSet<Core.Model.Status> Statuses { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Status.Config());
            modelBuilder.ApplyConfiguration(new Core.Model.Tasks.Config());
        }
    }
}
