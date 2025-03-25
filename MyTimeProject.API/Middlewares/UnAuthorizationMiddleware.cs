using MyTimeProject.API.Models;
using MyTimeProject.Core.Entities;
using MyTimeProject.Data;
using NLog;

namespace MyTimeProject.API.Middlewares
{
    public class UnAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public UnAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            logger.Warn("trying loggin!!");
            if(!context.User.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Why are you digging in places that don't concern you?");
                logger.Error($"user {context.User.Claims.ToList()} wanted digging and he didn't successful.... hahaha");
                return;
            }
            _next(context);
            logger.Info($"user {context.User.Claims.ToList()} came successful");
            
        }
        //private User AuthenticateUser(LoginModel loginModel)
        //{
        //    var user = _dataContext.Set<User>().FirstOrDefault(u => loginModel.UserName == u.Name);

        //    if (user != null && BCrypt.Net.BCrypt.Verify(loginModel.Password, user.Password))
        //    {
        //        return user;
        //    }

        //    return null;
        //}
    }
}
