using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Desafio.Easynvest.WebApi.Filters
{
    public class HandleExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public HandleExceptionsMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            this._next = next;
            this._env = env;
        }
        public async Task Invoke(HttpContext context, ILogger<HandleExceptionsMiddleware> logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, logger, e);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, ILogger<HandleExceptionsMiddleware> logger, Exception exception)
        {
            logger.LogError(exception, "Ocorreu um erro na chamada: ", context.Request.Method, context.Request.Path);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var exceptionInfo = new Dictionary<string, object>
            {
                ["Mensagem"] = "Ocorreu um erro na sua requisição. Tente novamente mais tarde."
            };

            if (this._env.IsDevelopment())
            {
                exceptionInfo["Mensagem"] = exception.Message;
                if (exception.InnerException != null)
                {
                    exceptionInfo["DetalhesErro"] = new Dictionary<string, object>
                    {
                        ["Erro"] = exception.InnerException.GetType().Name,
                        ["Detalhes"] = exception.InnerException.Message
                    };
                }
            }

            var result = JsonConvert.SerializeObject(exceptionInfo, JsonSerializerSettingsProvider.CreateSerializerSettings());

            return context.Response.WriteAsync(result);
        }
    }
}
