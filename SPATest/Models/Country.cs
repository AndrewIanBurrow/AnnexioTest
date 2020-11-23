using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPATest.Models
{
  /// <summary>
  /// Country object.  Some property names are lower case to facilitate the use of JsonSerializer.Deserialize.
  /// </summary>
  public class Country
  {
    public string name { get; set; }
    public string region { get; set; }
    public string subregion { get; set; }
    public string capital { get; set; }
    public long population { get; set; }
    public string alpha3Code { get; set; }
    public List<Currency> currencies { get; set; }
    public List<Language> languages { get; set; }
    //Border codes that are returned from the REST api.
    public string[] borders { get; set; }
    //Border countries are populated with country objects based on the borders returned by the REST api.
    public List<Country> BorderCountries { get; set; }
  }
}
