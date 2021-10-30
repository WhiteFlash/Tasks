using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.Core.Model;
using Tasks.DAL.Data;
using Tasks.DAL.Repository;

namespace Tasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private DataContextUnitOfWork _dataContextUnitOfWork;

        public NoteController(DataContext dataContext)
        {
            _dataContextUnitOfWork = new DataContextUnitOfWork(dataContext);
        }   
        
        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetTasksAsync()
        {
            return await Task.Factory.StartNew(() => _dataContextUnitOfWork.Notes.GetAll().ToList());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Note>> GetTaskAsync(int id)
        {
            var result = await Task.Factory.StartNew(() => _dataContextUnitOfWork.Notes.Get(id));
            if (result is null)
                return BadRequest();
            return Ok(result);
        }

        [Produces("application/json")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutTasksAsync(Note value)
        {
            if (value is null)
                return BadRequest();
            await Task.Factory.StartNew(() => _dataContextUnitOfWork.Notes.Update(value));
            _dataContextUnitOfWork.Save();
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Note>> PostTasksAsync([FromBody] Note value)
        {
            if (value is null)
                return BadRequest();
            await Task.Factory.StartNew(() => _dataContextUnitOfWork.Notes.Create(value));
            _dataContextUnitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteTasksAsync(int id)
        {
            if (id <= 0)
                return BadRequest();
            await Task.Factory.StartNew(() => _dataContextUnitOfWork.Notes.Delete(id));
            _dataContextUnitOfWork.Save();
            return Ok();
        }
    }
}
