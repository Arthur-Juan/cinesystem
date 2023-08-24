using System.Net;
using Application.DTOs.Response;
using Application.Errors.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi.Extensions;

public static class ErrorHandling
{
    public static void ConfigureErrorHandling(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(
            errorApp =>
            {
                errorApp.Run(async ctx =>
                {
                    var exptHandlerPathFeat = ctx.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exptHandlerPathFeat?.Error;

                    var code = (int)HttpStatusCode.InternalServerError;
                    var message = exception?.Message;
                    
                    if (exception is BadArgumentException)
                    {
                        code = (int)HttpStatusCode.BadRequest;
                        message = exception.Message;
                    }

                    ctx.Response.StatusCode = code;
                    ctx.Response.ContentType = "application/json";
                    await ctx.Response.WriteAsJsonAsync(new ErrorDto(
                        code, message
                        ));

                });
            }
            );
    }
}
