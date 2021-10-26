using Microsoft.EntityFrameworkCore;
using Tasks.Core.Model;


namespace Tasks.DAL.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Note> Notes { get; }
        IRepository<Status> Statuses { get; }
        void Save();
    }
}
