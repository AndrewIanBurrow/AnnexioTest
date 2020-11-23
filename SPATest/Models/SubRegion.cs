using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPATest.Models
{
  /// <summary>
  /// SubRegion object.  Some property names are lower case to facilitate the use of JsonSerializer.Deserialize.
  /// </summary>
  public class SubRegion
  {
    public string name { get; set; }
    public long population { get; set; }
    public List<Models.Country> Countries { get; set; }
    public string Region { get; set; }


  }
}
