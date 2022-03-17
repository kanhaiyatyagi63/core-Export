using Export.Model;
using Export.Utility;
using Microsoft.AspNetCore.Mvc;

namespace Export.Controllers
{
    public class CsvController : BaseController
    {

        [HttpGet, Route("GetFile")]
        public IActionResult Get()
        {
            // dummy data creation
            var list = GetWeatherDetail();

            var fileInfo = CsvUtility.GetFileContent<WeatherForecast>(list, "Weather.csv");

            return File(fileInfo.Stream, fileInfo.ContentType, fileInfo.FileName);
        }
    }
}
