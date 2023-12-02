namespace FootballLeagueApi.Web.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using System.Text.Json;
    using Data.Models;
    using Services.Handlers;

    public class ErrorHandler
    {
        private readonly RequestDelegate next;

        public ErrorHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case ArgumentException ae:
                        response.StatusCode = (int)HttpStatusCode.Conflict;
                        break;
                    case ResourceAlreadyExistsException raee:
                        response.StatusCode = (int)HttpStatusCode.Conflict;
                        break;
                    case ResourceNotFoundException knfe:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case UnauthorizedAccessException uae:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    case NullReferenceException nre:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new ErrorMessageResponse { Message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
