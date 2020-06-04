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
                        Description = pi.Description,
                    }),
                }).ToList();

            return cities;
        }
    }
}
