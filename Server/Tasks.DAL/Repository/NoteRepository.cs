using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks.Core.Model;
using Tasks.DAL.Data;
using Tasks.DAL.Data.Interfaces;

namespace Tasks.DAL.Repository
{
    class NoteRepository : IRepository<Note>
    {
        private DataContext _db;

        public NoteRepository(DataContext context)
        {
            _db = context;
        }


        public void Create(Note item)
        {
            _db.Notes.Add(item);   
        }

        public void Delete(int id)
        {
            Note note = _db.Notes.Find(id);
            if(note != null)
                _db.Notes.Remove(note);

        }

        public IEnumerable<Note> Find(Func<Note, bool> predicate)
        {
            return _db.Notes.Where(predicate).ToList();
        }

        public Note Get(int id)
        {
            return _db.Notes.Find(id);
        }

        public IEnumerable<Note> GetAll()
        {
            return _db.Notes.Include(x => x.Status);
        }

        public void Update(Note item)
        {
            _db.Update(item);
        }
    }
}
