using Microsoft.EntityFrameworkCore;
using Tasks.Core.Model;
using CustomTask = Tasks.Core.Model.Tasks;

namespace Tasks.DAL.Data.Interfaces
{
    public interface IDataContext
    {
        DbSet<CustomTask> Tasks { get; set; }
        DbSet<Status> Statuses { get; set; }
    }
}
