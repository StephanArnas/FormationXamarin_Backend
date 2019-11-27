using CryptoBankBackend.Common.Exceptions;
using CryptoBankBackend.Web.Models.Api;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBankBackend.Middlewares
{
    public class ExceptionMiddleware
    {
        #region ----- Attributes ------------------------------------------------------

        private readonly RequestDelegate _next = null;

        #endregion

        #region ----- Constructor -----------------------------------------------------

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion

        #region ----- Methods ---------------------------------------------------------

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        #endregion

        #region ----- Static Methods --------------------------------------------------

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json";

            if (exception is ExceptionBase)
            {
                var customException = exception as ExceptionBase;
                context.Response.StatusCode = customException.Code;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseErrorApi()
                {
                    Message = customException.Message,
                    Description = customException.Description
                }));
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseErrorApi()
                {
                    Message = exception.Message,
                    Description = string.Empty
                }));
            }
        }

        #endregion
    }
}
