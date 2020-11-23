using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPATest.Models
{
  /// <summary>
  /// Currency object.  Some property names are lower case to facilitate the use of JsonSerializer.Deserialize.
  /// </summary>

  public class Currency
  {
    public string code { get; set; }
    public string name { get; set; }
    public string symbol { get; set; }
  }
}
