using System;
using System.ComponentModel.DataAnnotations;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using System.Globalization;


namespace ParkAPI.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Type { get; set; }
    public double Score { get; set; }
  }

  public sealed class ParkMap : ClassMap<Park>
  {
    public ParkMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
        Map(m => m.ParkId).Ignore();
    }
  }
}
