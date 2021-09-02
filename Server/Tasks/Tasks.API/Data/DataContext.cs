using Microsoft.EntityFrameworkCore;
using Tasks.Core.Model;

namespace Tasks.API.Data
{ 
    public class DataContext : DbContext
    {
        public DbSet<Tasks.Core.Model.Tasks> Tasks { get; set; }
        public DbSet<Tasks.Core.Model.Status> Statuses { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Works
            modelBuilder.ApplyConfiguration(new Tasks.Core.Model.Status.Config());
            modelBuilder.ApplyConfiguration(new Tasks.Core.Model.Tasks.Config());
        }
    }
}
