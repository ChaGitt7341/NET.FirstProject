using NLog;

namespace MyTimeProject.API.Middlewares
{
    public class ShabesMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public ShabesMiddleware(RequestDelegate next)
        {
            _next = next;
            
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            logger.Info("ShabesMiddleware is beggining");
            var now = DateTime.Now;
            if(now.DayOfWeek== DayOfWeek.Saturday)
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                logger.Error("The request failed because it is Saturday.");
                return;
            }
            logger.Info("Today is not Saturday, the request is successful!");
            await _next(httpContext);
            
        }
    }
}
