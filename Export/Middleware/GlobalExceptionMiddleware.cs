using Export.Model;
using System.Net;
using System.Text.Json;


namespace Export.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GlobalExceptionMiddleware(RequestDelegate next,
            IWebHostEnvironment webHostEnvironment)
        {
            _next = next;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                var errorMessage = _webHostEnvironment.IsDevelopment() ?
                                   error.StackTrace : error.Message;
                response.ContentType = "application/json";

                var responseModel = ErrorResponseModel<string>.Error(errorMessage);

                switch (error)
                {
                    case CustomException e: // custom error handler
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e: // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default: // unhandled error or default error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }

    }
}
