using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CityInfoService.API.Controllers
{
    [ApiController]
    [Route("api/citiesInfo")]
    public class CitiesInfoController : ControllerBase
    {
        public ActionResult<IEnumerable<string>> GetCities()
        {
            return new JsonResult("Test answer");
        }
    }
}
