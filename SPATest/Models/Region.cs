using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPATest.Models
{
  /// <summary>
  /// Region object.  Some property names are lower case to facilitate the use of JsonSerializer.Deserialize.
  /// </summary>
  public class Region
  {
    public string name { get; set; }
    public long population { get; set; }
    public List<Models.Country> Countries { get; set; }
    public List<string> SubRegions { get; set; }
  }
}
