using CityInfoService.API.DataAccess;
using CityInfoService.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CityInfoService.API.Controllers
{
    [Route("api/citiesInfo/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly CityInfoContext context;

        public PointsOfInterestController(CityInfoContext context)
        {
            this.context = context;
        }

        //https://localhost:44348/api/pointsofinterest
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //http://api.example.com/games/1/platforms/34:
        //{
        //  "id": 34,
        //  "title": "Xbox",
        //  "publisher": "Microsoft",
        //  "releaseDate": "2015-01-01",
        //  "forms": [
        //    {"type": "edit", "fields: [] },
        //  ]
        //    }

        // https://localhost:44348/api/citiesInfo/1/pointsofinterest/1

        [HttpGet("{id}", Name = "GetPointOfInterest")]
        public IEnumerable<CityDto> GetPointOfInterest(int cityId, int id)
        {
            var cities = this.context
                .Cities.Include(c => c.PointsOfInterest)
                .Where(p => p.Id == cityId && p.Id == id)
                .Select(c => new CityDto
                {
                    Id = cityId,
                    Name = c.Name,
                    Description = c.Description,
                    PointsOfInterest = c.PointsOfInterest.Select(pi => new PointOfInterestDto 
                    { 
                        Id = pi.Id,
                        Name = pi.Name,
                        Description = pi.Description
                    })
                }).ToList();

            return cities;

        }
    }
}
