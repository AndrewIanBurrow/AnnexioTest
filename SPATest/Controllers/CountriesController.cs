using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SPATest.Controllers
{
  /// <summary>
  /// Countries controller.  Contains public asynchronous methods for controlling the views
  /// </summary>
  public class CountriesController : Controller
  {
    //Get list of countries from the CountryFunctions class and display view.
    public async Task<IActionResult> Index(string searchString)
    {
      return View(await CountryFunctions.GetCountries(searchString));
    }

    //Get country details from the CountryFunctions class and display view.
    public async Task<IActionResult> Country(string id)
    {
      if (id == null)
        return NotFound();

      var country = await CountryFunctions.GetCountryByCode(id);

      if (country == null)
        return NotFound();

      return View(country);
    }

    //Get region details from the CountryFunctions class and display view.
    public async Task<IActionResult> Region(string id)
    {
      if (id == null)
        return NotFound();

      var region = await CountryFunctions.GetRegion(id);

      if (region == null)
        return NotFound();

      return View(region);
    }

    //Get sub-region from the CountruyFunctions class and display view.
    public async Task<IActionResult> SubRegion(string id)
    {
      if (id == null)
        return NotFound();

      var subRegion = await CountryFunctions.GetSubRegion(id);

      if (subRegion == null)
        return NotFound();

      return View(subRegion);
    }
  }
}
