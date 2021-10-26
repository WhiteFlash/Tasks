using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.API.Abstractions.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllItems();
        Task<T> GetItem(int id);
    }
}
