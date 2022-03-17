using Export.Model;
using Export.Utility;
using Microsoft.AspNetCore.Mvc;

namespace Export.Controllers
{
    public class XmlController : BaseController
    {

        [HttpGet, Route("GetFile")]
        public IActionResult Get()
        {
            // dummy data creation
            var list = GetWeatherDetail();

            var fileInfo = XmlUtility.GetFileContent<WeatherForecast>(list, "Weather.xml", "WeatherForCast", "Weather");
            return File(fileInfo.Stream, fileInfo.ContentType, fileInfo.FileName);
        }
    }
}
