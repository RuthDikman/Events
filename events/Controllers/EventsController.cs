using System.Reflection;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
       private readonly IDataContext _context;
        private static int count = 0;
        public EventsController(IDataContext dataContext)
        {
            _context = dataContext;
        }
        // GET: api/<EventController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_context.EventList);
        }

        //GET api/<EventController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var eve = _context.EventList.Find(e => e.Id == id);
            if (eve is null)
            {
                return NotFound();
            }
            return Ok(eve);
        }

        // POST api/<EventController>
        [HttpPost]
        public CreatedAtActionResult Post([FromBody] Event value)
        {
            var eve = new Event { Id = count++, Title = value.Title, Start = value.Start, End=value.End };
            _context.EventList.Add(eve);
            return CreatedAtAction("Get", new { id = eve.Id }, eve);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Event value)
        {
            var ev = _context.EventList.Find(x => x.Id == id);
            if (ev == null)
            {
                return NotFound();
            }
            ev.Title = value.Title;
            return NoContent();
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ev = _context.EventList.Find(x => x.Id == id);
            if (ev == null)
            {
                return NotFound();
            }

            _context.EventList.Remove(ev);
            return NoContent();
        }
    }
}
