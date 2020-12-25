﻿using System.Threading.Tasks;
using WeatherForecast.Data.OpenWeather.Dto.Forecast;

namespace WeatherForecast.Data.OpenWeather.Clients
{
    public interface IForecastClient
    {
        Task<ForecastResponse> GetByCityName(string name);
        Task<ForecastResponse> GetById(int id);
    }
}