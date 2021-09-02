using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.DAL.Data.Interfaces
{
    public interface IDataContext
    {
        DbSet<Core.Model.Tasks> Tasks { get; set; }
        DbSet<Core.Model.Status> Statuses { get; set; }
    }
}
