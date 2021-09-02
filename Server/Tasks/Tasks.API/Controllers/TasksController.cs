using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasks.DAL.Data;
using Tasks.Core.Model;


namespace Tasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly DataContext _context;

        public TasksController(DataContext context)
        {
            _context = context;
            if (!_context.Tasks.Any())
            {
                InitializeDB.Initialize(context);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetTasks()
        {
            return new JsonResult(await _context.Tasks.Include(x => x.Status).ToListAsync());
        }

        [Produces("application/json")]
        [HttpPut("{id}")]
        public async Task<JsonResult> PutTasks(int id, Tasks.Core.Model.Tasks tasks)
        {
            JsonResult json = new JsonResult(tasks);
            if (id != tasks.TasksID)
            {
                json.StatusCode = 400;
                return json;
            }

            _context.Entry(tasks).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            json.StatusCode = 200;

            return json;
        }

        [HttpPost]
        public async Task<ActionResult<Tasks.Core.Model.Tasks>> PostTasks([FromBody] Tasks.Core.Model.Tasks tasks)
        {
            try
            {
                _context.Tasks.Add(tasks);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTasks", new { id = tasks.TasksID }, tasks);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasks([FromBody] int id)
        {
            var tasks = await _context.Tasks.FirstOrDefaultAsync(element => element.TasksID == id);
            if (tasks == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(tasks);
            await _context.SaveChangesAsync();

            return Ok($"Элемент {id} удалён");
        }
    }
}
