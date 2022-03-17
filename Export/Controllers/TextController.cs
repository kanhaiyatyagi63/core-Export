using Export.Model;
using Export.Utility;
using Microsoft.AspNetCore.Mvc;

namespace Export.Controllers
{
    public class TextController : BaseController
    {
        [HttpGet, Route("GetFile")]
        public IActionResult Get()
        {
            // dummy data creation
            var list = GetWeatherDetail();

            var fileInfo = TextUtility.GetFileContent<WeatherForecast>(list, "Weather.txt", "application/Text", ",",";",  true);
            return File(fileInfo.Stream, fileInfo.ContentType, fileInfo.FileName);
        }
    }
}
