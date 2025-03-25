using NLog;

namespace MyTimeProject.API.Middlewares
{
    public class LogMiddleware
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            logger.Info($"Request {context.Request.Method} started");
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"failed! {ex.Message}");
            }

            logger.Info($"status: {context.Response.StatusCode}");
        }
    }
}
