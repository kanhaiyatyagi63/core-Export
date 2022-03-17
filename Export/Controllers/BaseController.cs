using Export.Model;
using Microsoft.AspNetCore.Mvc;

namespace Export.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
         {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
         };

        [NonAction]
        public List<WeatherForecast> GetWeatherDetail()
        {
            return Enumerable.Range(1, 15).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }
    }
}
