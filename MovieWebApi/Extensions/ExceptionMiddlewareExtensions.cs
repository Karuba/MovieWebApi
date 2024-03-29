﻿using LoggerService;
using Microsoft.AspNetCore.Diagnostics;
using MovieWebApi.Domain.Core.ErrorModel;
using System.Net;

namespace MovieWebApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder builder, ILoggerManager logger)
        {
            builder.UseExceptionHandler(buildError =>
                buildError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (context != null)
                    {
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server error"
                        }.ToString());
                    }
                })
            );

        }
    }
}
