using CityInfoService.API.DataAccess;
using CityInfoService.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace CityInfoService.API.Controllers
{                                                                   //implement the CRUD
    [ApiController]
    [Route("api/citiesInfo")]
    public class CitiesInfoController : ControllerBase
    {
        private readonly CityInfoContext context;

        public CitiesInfoController(CityInfoContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = this.context.Cities.ToList();

            return this.Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCityById(int id)
        {
            City city = this.context
                .Cities.FirstOrDefault(c => c.Id == id);

            return this.Ok(city);
        }
    }
}
