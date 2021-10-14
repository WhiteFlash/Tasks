using Microsoft.EntityFrameworkCore;
using Tasks.Core.Model;


namespace Tasks.DAL.Data.Interfaces
{
    public interface IDataContext
    {
        DbSet<Note> Notes { get; set; }
        DbSet<Status> Statuses { get; set; }
    }
}
