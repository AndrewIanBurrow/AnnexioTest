using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SPATest
{
  /// <summary>
  /// Country functions.  Provides methods for retreiving country and region data from the RESTful api
  /// </summary>
  public class CountryFunctions
  {
    /// <summary>
    /// Search for countries matching searchString or return all countries if left blank.
    /// </summary>
    public static async Task<List<Models.Country>> GetCountries(string searchString)
    {
      //Use HttpClient to asynchronously retrieve data from the REST api.
      HttpClient client = new HttpClient();
      var msg = await client.GetStringAsync("https://restcountries.eu/rest/v2/" + (String.IsNullOrEmpty(searchString) ? "all" : "name/" + searchString));

      //Deserialize the json text to Models.Country objects.
      List<Models.Country> countries = JsonSerializer.Deserialize<List<Models.Country>>(msg);

      //Return a list of Models.Country.
      return countries;
    }


    /// <summary>
    /// Returns a single country by countryCode
    /// </summary>
    public static async Task<Models.Country> GetCountryByCode(string countryCode)
    {
      //Use HttpClient to asynchronously retrieve data from the REST api.
      HttpClient client = new HttpClient();
      var msg = await client.GetStringAsync("https://restcountries.eu/rest/v2/");

      //Deserialize the json text to Models.Country objects.
      List<Models.Country> countries = JsonSerializer.Deserialize<List<Models.Country>>(msg);

      //Select the country that matches the countryCode.
      var country = (from c in countries
                     where c.alpha3Code == countryCode
                     select c).FirstOrDefault();

      //Get all border countries by alpha3Code and add to BorderCountries.
      country.BorderCountries = new List<Models.Country>();
      foreach (string border in country.borders)
      {
        country.BorderCountries.Add((from c in countries
                                     where c.alpha3Code.Equals(border)
                                     select c).FirstOrDefault());
      }

      //Return a list of Models.Country.
      return country;
    }

    /// <summary>
    /// FReturns a single region by regionName
    /// </summary>
    public static async Task<Models.Region> GetRegion(string regionName)
    {
      //Create a new Models.Region object to return.
      Models.Region region = new Models.Region();
      //Fill region name in as we already know it.
      region.name = regionName;

      //Use HttpClient to asynchronously retrieve region data from the REST api by regionName.
      HttpClient client = new HttpClient();
      var msg = await client.GetStringAsync("https://restcountries.eu/rest/v2/region/" + regionName);

      //Deserialize the json text to Models.Country objects.
      region.Countries = JsonSerializer.Deserialize<List<Models.Country>>(msg);
      //Calculate population of all countries in region.
      region.population = region.Countries.Sum(c => c.population);
      //Create a list of Models.SubRegion that belong to this region.
      region.SubRegions = region.Countries.Select(c => c.subregion).Distinct().ToList();

      return region;
    }

    /// <summary>
    /// Returns a single sub-region by subRegionName
    /// </summary>
    public static async Task<Models.SubRegion> GetSubRegion(string subRegionName)
    {
      Models.SubRegion subRegion = new Models.SubRegion();

      subRegion.name = subRegionName;

      //Use HttpClient to asynchronously retrieve region data from the REST api by regionName.
      HttpClient client = new HttpClient();
      var msg = await client.GetStringAsync("https://restcountries.eu/rest/v2/");

      //Deserialize the json text to Models.Country objects.
      List<Models.Country> countries = JsonSerializer.Deserialize<List<Models.Country>>(msg);

      //Populate loist of countries belonging to this sub-region.
      subRegion.Countries = countries.Where(c => c.subregion.Equals(subRegionName)).ToList();
      //Calculate population of all countries in sub-region.
      subRegion.population = subRegion.Countries.Sum(c => c.population);
      //The region that this sub-region belongs to.
      subRegion.Region = subRegion.Countries.Where(c => !String.IsNullOrEmpty(c.region)).FirstOrDefault().region;

      return subRegion;
    }
  }
}
