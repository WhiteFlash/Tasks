using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.API.Abstractions.Interfaces;
using Tasks.Core.Model;
using Tasks.DAL.Data;

namespace Tasks.API.ControllerLogic
{
    public class NoteRepo : IRepository<Note>
    {
        private DataContext _context;

        public NoteRepo(DataContext context)
        {
            _context = context;
            if (context.Database.EnsureCreated())
            {   
                InitializeDB.Initialize(context);
            }
        }

        public IEnumerable<Note> GetAllItems()
        {
            return _context.Notes.Take(20).ToList();    
        }

        public Task<Note> GetItem(int id)
        {
            throw new NotImplementedException();
        }
    }
}
