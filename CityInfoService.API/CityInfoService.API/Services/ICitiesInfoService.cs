using CityInfoService.API.Dtos;
using CityInfoService.API.Models;
using System.Collections.Generic;

namespace CityInfoService.API.Services
{
    public interface ICitiesInfoService
    {
        IEnumerable<City> GetCities();

        City GetCityById(int cityId);

        bool CityExists(int cityId);

        void DeleteCity(City city);

        bool Save();

        void CreateCity(CityForCreationDto creationDto);
    }
}
