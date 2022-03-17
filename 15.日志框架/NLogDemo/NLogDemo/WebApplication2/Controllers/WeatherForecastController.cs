using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        static List<WeatherForecast> weatherForecasts = new List<WeatherForecast>(){ new WeatherForecast()
        {
            Date = DateTime.Now,
            TemperatureC = 20,
            Summary = "晴天",
            Id = 1
        } };

        [HttpGet]
        public WeatherForecast Get(int id)
        {
            RedisClient client = new RedisClient("127.0.0.1");
            string key = "Weather_" + id;
            // 1. 先从Redis里面找
            var ret= client.Get<WeatherForecast>(key);

            // 2. 若Redis里面没有，则数据库操作
            if (ret == null)
            {
                ret = weatherForecasts.Single(a => a.Id == id);

                client.Set(key, ret, DateTime.Now.AddMinutes(5));
            }

            return ret;
        }

        [HttpPut]
        public void Update(WeatherForecast forecast)
        {
            // 1. 从数据库更新数据
            weatherForecasts.RemoveAll(a => a.Id == forecast.Id);
            weatherForecasts.Add(forecast);

            // 2. 清除缓存
            RedisClient client = new RedisClient("127.0.0.1");
            string key = "Weather_" + forecast.Id;
            client.Remove(key);
        }
    }
}
