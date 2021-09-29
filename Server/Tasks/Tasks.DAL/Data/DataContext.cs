using Microsoft.EntityFrameworkCore;
using Tasks.Core.Model;
using Tasks.DAL.Data.Interfaces;
using CustomTasks = Tasks.Core.Model.Tasks;

namespace Tasks.DAL.Data
{ 
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<CustomTasks> Tasks { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Status.Config());
            modelBuilder.ApplyConfiguration(new CustomTasks.Config());
        }
    }
}
