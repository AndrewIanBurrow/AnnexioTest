using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPATest.Models
{
  /// <summary>
  /// Language object.  Some property names are lower case to facilitate the use of JsonSerializer.Deserialize.
  /// </summary>
  public class Language
  {
    public string iso639_1 { get; set; }
    public string iso639_2 { get; set; }
    public string name { get; set; }
    public string nativeName { get; set; }
  }
}
