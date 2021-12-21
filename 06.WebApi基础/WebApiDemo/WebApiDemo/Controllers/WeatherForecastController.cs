using DtoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
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

        [HttpGet]
        public string GetTest()
        {
            return "Test";
        }

        // 有/表示是从根开始，没有表示是承接Controller的Route
        [Route("{a}")]
        [HttpPost]
        public string PostTest([Required]string a)
        {
            return a;
        }

        [HttpPost]
        public AnimalDto PostDto(AnimalDto dto)
        {
            return dto;
        }

        [HttpPost]
        public ActionResult<AnimalDto> PostDto2(AnimalDto dto)
        {
            if (dto.Name == null)
            {
                return NotFound();
            }
            else return dto;
        }


        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
