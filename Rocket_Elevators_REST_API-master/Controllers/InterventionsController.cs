using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketApi.Models;

namespace RocketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly RocketContext _context;

        public InterventionsController(RocketContext context)
        {
            _context = context;
        }

        // GET: api/Interventions: All interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventions()
        {
            return await _context.Interventions.ToListAsync();
        }

        // GET: api/interventions/10
        [HttpGet("{id}")]
        public async Task<ActionResult<Interventions>> GetInterventions(long id)
        {
            var interventions = await _context.Interventions.FindAsync(id);

            if (interventions == null)
            {
                return NotFound();
            }

            return interventions;
        }


        // 1.  Retrieving the current status of a specific Intervention

        // GET: api/Interventions/{id}/status
        [HttpGet("{id}/Status")]
        public async Task<ActionResult<string>> GetInterventionStatus([FromRoute] long id)
        {
            var bb = await _context.Interventions.FindAsync(id);

            if (bb == null)
                return NotFound();
            Console.WriteLine("Get intervention status", bb.Status);

            return bb.Status;

        }

        //  2. Changing the status of a specific Interventions 

        [HttpPut("{id}/Status/")]
        public async Task<IActionResult> UpdateStatus([FromRoute] long id, Interventions current)
        {

            if (id != current.Id)
            {
                return BadRequest();
            }

            if (current.Status == "Active" || current.Status == "Inactive" || current.Status == "Intervention")
            {
                _context.Entry(current).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Content("Interventions: " + current.Id + ", status as been change to: " + current.Status);
            }

            return Content("Please insert a valid status : Intervention, Inactive, Active, Tray again !  ");
        }




        // DELETE: api/Interventions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interventions>> DeleteInterventions(long id)
        {
            var interventions = await _context.Interventions.FindAsync(id);
            if (interventions == null)
            {
                return NotFound();
            }

            _context.Interventions.Remove(interventions);
            await _context.SaveChangesAsync();

            return interventions;
        }




        private bool InterventionsExists(long id)
        {
            return _context.Interventions.Any(e => e.Id == id);
        }
    }
}
