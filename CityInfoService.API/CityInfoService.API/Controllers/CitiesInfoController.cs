using CityInfoService.API.Dtos;
using CityInfoService.API.Models;
using CityInfoService.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CityInfoService.API.Controllers
{
    [ApiController]                                                 // 1. make Services & register them in StartUp, DI, IoC
    [Route("api/citiesInfo")]                                       // 2. make actions async & return Task<T>
    public class CitiesInfoController : ControllerBase              // 3. check for null values in DB 
    {
        private readonly ICitiesInfoService citiesInfoService;

        public CitiesInfoController(ICitiesInfoService citiesInfoService)
        {
            this.citiesInfoService = citiesInfoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<City>> GetCities()
        {
            var cities = this.citiesInfoService.GetCities();

            return this.Ok(cities);
        }

        [HttpGet("{id}")]
        public ActionResult<City> GetCityById(int id)
        {
            var city = this.citiesInfoService.GetCityById(id);

            if (city == null)
            {
                return this.NotFound();
            }

            return this.Ok(city);
        }

        [HttpPost]
        public ActionResult<City> CreateCity([FromBody]CityForCreationDto cityDto)
        {
            this.citiesInfoService.CreateCity(cityDto);

            return this.Ok();


            //return this.CreatedAtAction("GetCityById", new { id = city.Id }, city);

            //newly created obj returned in the headers => OK https://localhost:44348/api/citiesInfo/11
        }

        //[HttpPut("{id}")]
        //public ActionResult<City> UpdateCity(int id, [FromBody] CityForUpdateDto cityDto)
        //{
        //    City city = this.context.Cities.FirstOrDefault(c => c.Id == id);
        //    city.Name = cityDto.Name;
        //    city.Description = cityDto.Description;
        //    this.context.SaveChanges();

        //    return city;  // if it returns the updated city  == Checked out!
        //}

        [HttpDelete("{id}")]
        public ActionResult<City> DeleteCity(int id)   // NB! MUST be with the same name
        {
            if (!this.citiesInfoService.CityExists(id))
            {
                return this.NotFound();
            }

            var city = this.citiesInfoService.GetCityById(id);

            this.citiesInfoService.DeleteCity(city);

            return this.NoContent();
        }
    }
}
