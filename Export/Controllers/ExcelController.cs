using Export.Model;
using Export.Utility;
using Microsoft.AspNetCore.Mvc;

namespace Export.Controllers
{
    public class ExcelController : BaseController
    {

        [HttpGet, Route("GetFile")]
        public IActionResult Get()
        {

            // dummy data creation
            var list = GetWeatherDetail();

            var fileInfo = ExcelUtility.GetFileContent<WeatherForecast>(list, "Weather", "Weather.xlsx");
            return File(fileInfo.Stream, fileInfo.ContentType, fileInfo.FileName);
        }
    }
}
