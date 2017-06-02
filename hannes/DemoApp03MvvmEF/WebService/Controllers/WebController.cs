using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerServices;
using ServerModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebService.Controllers
{
    [Route("api/developers")]
    public class WebDeveloperController : Controller
    {
        private DbDeveloperContext _context;

        public WebDeveloperController( DbDeveloperContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public IEnumerable<Developer> GetDevelopers()
        {
            return _context.Developers.ToList();
        }

        // GET
        [HttpGet("{id}", Name = nameof(GetDeveloperById))]
        public IActionResult GetDeveloperById(int id)
        {
            Developer dev = _context.Developers.Where( d => d.Id == id ).SingleOrDefault();
            if (dev == null)
            {
                return NotFound();
            }

            return Ok(dev);
        }

        // POST
        [HttpPost]
        public IActionResult PostDeveloper([FromBody] Developer dev)
        {
            _context.Developers.Add(dev);
            _context.SaveChanges();

            return CreatedAtRoute(nameof(GetDeveloperById), new { id = dev.Id }, dev);
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


        // PUT api/values/5
        [HttpPut("{id}")]
        public void PutDeveloper(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteDeveloper(int id)
        {
        }
    }
}
