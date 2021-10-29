using System;
using System.ComponentModel.DataAnnotations;
using CsvHelper;

namespace ParkAPI.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    [Required]
    [Index(2)]
    public string Name { get; set; }
    [Index(5)]
    public string Type { get; set; }
    [Index(4)]
    public double Score { get; set; }
  }
}
