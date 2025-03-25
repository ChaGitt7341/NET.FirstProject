using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyTimeProject.Core.Entities;
using NLog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyTimeProject.API.Middlewares
{
    public class TokenMiddlware
    {
        private readonly IConfiguration _configuration;
        private readonly RequestDelegate _next;

        public TokenMiddlware(IConfiguration configuration, RequestDelegate next)
        {
            _configuration = configuration;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // בדוק אם יש טוקן
            var token = context.Request.Headers["Authorization"].ToString();

            if (!string.IsNullOrEmpty(token))
            {
                var newToken = GenerateToken(context.User.Claims); // יצירת טוקן חדש
                context.Response.Headers.Add("New-Token", newToken);
            }
            
            

            await _next(context);
        }

        //private bool IsTokenValid(string token)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key"));

        //    try
        //    {
        //        tokenHandler.ValidateToken(token, new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(key),
        //            ValidateIssuer = true,
        //            ValidIssuer = _configuration.GetValue<string>("JWT:Issuer"),
        //            ValidateAudience = true,
        //            ValidAudience = _configuration.GetValue<string>("JWT:Audience"),
        //            ClockSkew = TimeSpan.Zero // אין דחייה
        //        }, out SecurityToken validatedToken);

        //        return true; // הטוקן תקף
        //    }
        //    catch
        //    {
        //        return false; // הטוקן לא תקף
        //    }
        //}

        private string GenerateToken(IEnumerable<Claim> currentUserClaims)
        {
           

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JWT:Issuer"),
                audience: _configuration.GetValue<string>("JWT:Audience"),
                claims: currentUserClaims, // הוסף את ה-Claims כאן
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
