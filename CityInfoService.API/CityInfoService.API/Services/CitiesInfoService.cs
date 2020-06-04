using CityInfoService.API.DataAccess;
using CityInfoService.API.Dtos;
using CityInfoService.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CityInfoService.API.Services
{
    public class CitiesInfoService : ICitiesInfoService
    {
        private readonly CityInfoContext context;

        public CitiesInfoService(CityInfoContext context)
        {
            this.context = context;
        }

        public IEnumerable<City> GetCities()
        {
            var cities = this.context
                .Cities
                .ToList();

            return cities;
        }

        public City GetCityById(int cityId)
        {
            var city = this.context
                .Cities
                .Where(c => c.Id == cityId)
                .FirstOrDefault();

            return city;
        }

        public bool CityExists(int cityId)
        {
            return this.context
                .Cities
                .Any(city => city.Id == cityId);
        }

        public void DeleteCity(City city)
        {
            var cityToRemove = this.context
                .Cities
                .Remove(city);

            this.Save();
        }

        public bool Save()
        {
            return this.context.SaveChanges() >= 0;
        }

        public void CreateCity(CityForCreationDto creationDto)
        {
            City city = new City                                       
            {
                Name = creationDto.Name,
                Description = creationDto.Description
            };

            this.context.Cities.Add(city);
            this.context.SaveChanges();

        }
    }
}
