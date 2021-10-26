using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks.Core.Model;
using Tasks.DAL.Data;
using Tasks.DAL.Data.Interfaces;

namespace Tasks.DAL.Repository
{
    class StatusRepository : IRepository<Status>
    {
        private DataContext _db;

        public StatusRepository(DataContext context)
        {
            _db = context;
        }

        public void Create(Status item)
        {
            _db.Statuses.Add(item); 
        }

        public void Delete(int id)
        {
            Status status = _db.Statuses.Find(id);
            if(status != null)
                _db.Statuses.Remove(status);    
        }

        public IEnumerable<Status> Find(Func<Status, bool> predicate)
        {
            return _db.Statuses.Where(predicate).ToList();
        }

        public Status Get(int id)
        {
            return _db.Statuses.Find(id);   
        }

        public IEnumerable<Status> GetAll()
        {
            return _db.Statuses.ToList();
        }

        public void Update(Status item)
        {
            _db.Statuses.Update(item);
        }
    }
}
