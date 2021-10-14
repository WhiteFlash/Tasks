using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasks.DAL.Data;
using Newtonsoft;
using Tasks.DAL.Data.Interfaces;
using Tasks.API.ControllerLogic;
using Tasks.Core.Model;

namespace Tasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly NoteRepo _noteRepo;

        public NoteController(DataContext dataContext)
        {
            _noteRepo = new NoteRepo(dataContext);
        }

        [HttpGet]
        public ActionResult<List<Note>> GetTasks()
        {
            var notes = _noteRepo.GetAllItems();
            return notes.ToList();
        }

        [Produces("application/json")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutTasks(int id, Note note)
        {
            //JsonResult json = new JsonResult(tasks);
            //if (id != tasks.TasksID)
            //{
            //    json.StatusCode = 400;
            //    return json;
            //}

            //_context.Entry(tasks).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            //json.StatusCode = 200;

            //return json;
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Note>> PostTasks([FromBody] Note value)
        {
            //try
            //{
            //    _context.Tasks.Add(tasks);
            //    await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetTasks", new { id = tasks.TasksID }, tasks);
            //}
            //catch (Exception ex) { throw new Exception(ex.Message); }
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTasks([FromBody] int id)
        {
            //CustomTask tasks = await _context.Tasks.FirstOrDefaultAsync(element => element.TasksID == id);
            //if (tasks == null)
            //{
            //    return NotFound();
            //}

            //_context.Tasks.Remove(tasks);
            //await _context.SaveChangesAsync();

            return Ok($"Элемент {id} удалён");
        }
    }
}
