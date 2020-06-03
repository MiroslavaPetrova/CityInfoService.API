using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityInfoService.API.Models
{
    public class City
    {
        public City()
        {
            this.PointsOfInterest = new List<PointOfInterest>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Description { get; set; }

        public IEnumerable<PointOfInterest> PointsOfInterest { get; set; }
    }
}
