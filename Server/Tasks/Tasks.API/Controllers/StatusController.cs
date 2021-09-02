using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.DAL.Data;

namespace Tasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        readonly DataContext _context;
        public StatusController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult Get()
        {
            JsonResult jsonresult = new JsonResult(_context.Statuses)
            {
                StatusCode = 200
            };

            if (_context.Statuses == null)
            {
                jsonresult.StatusCode = 400;            
            }
            
            return jsonresult;
        }
    }
}
