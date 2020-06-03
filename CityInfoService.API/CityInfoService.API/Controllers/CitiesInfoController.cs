using CityInfoService.API.DataAccess;
using CityInfoService.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CityInfoService.API.Controllers
{                                                                   // 1.implement the CRUD
    [ApiController]                                                 // 2.make a Reposictory to get the data from DB
    [Route("api/citiesInfo")]                                       // 3.create DTOs 
    public class CitiesInfoController : ControllerBase              // 4.create DIC
    {
        private readonly CityInfoContext context; // => Service Layer

        public CitiesInfoController(CityInfoContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<City>> GetCities()
        {
            var cities = this.context.Cities.ToList();

            return this.Ok(cities);
        }

        [HttpGet("{id}")]
        public ActionResult<City> GetCityById(int id)
        {
            City city = this.context
                .Cities.FirstOrDefault(c => c.Id == id);

            return city;
        }

        [HttpPost]
        public ActionResult<City> CreateCity(City inputCityModel)
        {
            this.context.Cities.Add(inputCityModel);
            this.context.SaveChanges();

            return this.CreatedAtAction("GetCityById", new { id = inputCityModel.Id }, inputCityModel);

            // test if it returns the new URI in Postman headers
            //  {
            //   "name": "TEST",
            //   "description": "The one for the TEST purposes.",
            //   "pointsOfInterest": []
            //  }
        }

        [HttpPut("{id}")]
        public ActionResult<City> UpdateCity(City inputCityModel)
        {
            City city = this.context.Cities.FirstOrDefault(c => c.Id == inputCityModel.Id);
            city.Name = inputCityModel.Name;
            city.Description = inputCityModel.Description;
            this.context.SaveChanges();

            return city;  // if it returns the updated city??
        }

        [HttpDelete("{id}")]
        public ActionResult<City> DeleteCity(int id)
        {
            var city = this.context.Cities.SingleOrDefault(c => c.Id == id);
            this.context.Cities.Remove(city);
            this.context.SaveChanges();

            return this.Ok(city);
        }
    }
}
