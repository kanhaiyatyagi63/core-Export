using Export.Model;
using Export.Utility;
using Microsoft.AspNetCore.Mvc;

namespace Export.Controllers
{
    public class JsonController : BaseController
    {
        [HttpGet, Route("GetFile")]
        public IActionResult Get()
        {

            // dummy data creation
            var list = GetWeatherDetail();

            var fileInfo = JsonUtility.GetFileContent<WeatherForecast>(list, "Weather.json");
            return File(fileInfo.Stream, fileInfo.ContentType, fileInfo.FileName);
        }
    }
}
