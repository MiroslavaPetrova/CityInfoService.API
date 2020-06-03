﻿using CityInfoService.API.Models;
using System.Collections.Generic;

namespace CityInfoService.API.Dtos
{
    public class CityDto
    {
        public CityDto()
        {
            this.PointsOfInterest = new List<PointOfInterestDto>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<PointOfInterestDto> PointsOfInterest { get; set; }
    }
}
