using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkAPI.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using System.Globalization;

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

    // public sealed class ParkMap : ClassMap<Park>
    // {
    //     public ParkMap()
    //     {
    //         AutoMap(CultureInfo.InvariantCulture);
    //         Map(m => m.ParkId).Ignore();
    //     }
    // }
    [HttpGet("load")]
    public async Task<ActionResult<IEnumerable<Park>>> LoadParks()
    {
      // var config = new CsvConfiguration(CultureInfo.InvariantCulture)
      // {
      //   HeaderValidated = null;
      // };
      using (var streamReader = new StreamReader("./Models/SeedData/SF_Park_Scores.csv"))
      {
        using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
        {
          csvReader.Context.RegisterClassMap<ParkMap>();
          var parkRecords = csvReader.GetRecords<Park>().ToList();
          Console.WriteLine($"# of Parks: {parkRecords.Count}");
          
          _db.Parks.AddRange(parkRecords);
          _db.SaveChanges();
        }
      }

      return await _db.Parks.ToListAsync();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> GetParks(string type, int minScore, int maxScore, bool sorted = false)
    {
      var query = _db.Parks.AsQueryable();

      if(type != null)
      {
        query = query.Where(park => park.Type == type);
      }
      if(minScore != 0)
      {
        query = query.Where(park => park.Score >= minScore);
      }
      if(maxScore != 0)
      {
        query = query.Where(park => park.Score <= maxScore);
      }
      if(sorted)
      {
        query = query.OrderByDescending(park => park.Score);
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