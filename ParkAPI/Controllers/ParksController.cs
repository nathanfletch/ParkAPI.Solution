using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkAPI.Models;

namespace ParkAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParkAPIContext _db;

    public ParksController(ParkAPIContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> GetParks(string type)
    {
      var query = _db.Parks.AsQueryable();

      if(type != null)
      {
        query = query.Where(park => park.Type == type);
      }

      return await query.ToListAsync();
    }
    
    [HttpPost]
    public async Task<ActionResult<Park>> Post([FromBody] Park park)
    {
      _db.Parks.Add(park);
      
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = park.ParkId }, park);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      var park = await _db.Parks.FindAsync(id);

      if (park == null)
      {
        return NotFound();
      }

      return park;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      var parkToDelete = await _db.Parks.FirstOrDefaultAsync(entry => entry.ParkId == id);
      if (parkToDelete == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(parkToDelete);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPark(int id, [FromBody]Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }
    
      _db.Entry(park).State = EntityState.Modified;
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}