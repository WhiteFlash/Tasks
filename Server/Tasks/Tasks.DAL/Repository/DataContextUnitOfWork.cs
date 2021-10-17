using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Core.Model;
using Tasks.DAL.Data;
using Tasks.DAL.Data.Interfaces;

namespace Tasks.DAL.Repository
{
    class DataContextUnitOfWork : IUnitOfWork
    {
        private DataContext _db;
        private NoteRepository _noteRepository;
        private StatusRepository _statusRepository;

        public DataContextUnitOfWork(DataContext context)
        {
            _db = context;
        }

        public IRepository<Note> Notes
        {
            get
            {
                if (_noteRepository == null)
                    _noteRepository = new NoteRepository(_db);
                return _noteRepository;
            }
        }
        public IRepository<Status> Statuses
        {
            get
            {
                if (_statusRepository == null)
                    _statusRepository = new StatusRepository(_db);
                return _statusRepository;
            }
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
