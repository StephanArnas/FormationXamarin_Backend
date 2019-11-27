using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoBankBackend.Common.Extensions
{
    public static class HttpContextExtension
    {
        public static int GetUserId(this HttpContext httpContext)
        {
            var userIdString = httpContext.Request.Headers.FirstOrDefault(x => x.Key == "UserId").Value.FirstOrDefault();
            if (!int.TryParse(userIdString, out int userId))
            {
                throw new UnauthorizedAccessException("Missing UserId Token with the user Id value.");
            }
            else return userId;
        }
    }
}
