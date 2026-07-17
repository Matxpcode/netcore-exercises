using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DesafioMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareValidacion
    {
        private readonly RequestDelegate _next;

        public MiddlewareValidacion(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string path = httpContext.Request.Path.ToString().ToLower();
            string method = httpContext.Request.Method;

            if (path == "/" && method == "POST")
            {
                if (!httpContext.Request.HasFormContentType)
                {
                    //pregunta 3 (seria por defecto ya q inicialmente no hay parametros)
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("<h1>Invalid input for 'email'</h1><br>");
                    await httpContext.Response.WriteAsync("<h1>Invalid input for 'password'</h1>");
                    return;
                }

                string correo = httpContext.Request.Form["email"];
                string contrasena = httpContext.Request.Form["password"];

                httpContext.Response.Headers["Content-Type"] = "text/html; charset=utf-8";

                //pregunta 4
                if (string.IsNullOrEmpty(correo))
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("<h1>Invalid input for 'email'</h1>");
                    return;
                }
                else if (string.IsNullOrEmpty(contrasena))
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("<h1>Invalid input for 'password'</h1>");
                    return;
                }

                //pregunta 1 y 2
                if (correo == "admin@example.com" && contrasena == "admin1234")
                {
                    httpContext.Response.StatusCode = 200;
                    await httpContext.Response.WriteAsync("<h1>Successfull login</h1>");
                }
                else
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("<h1>Invalid login</h1>");
                }
                return;
            }

            if (path=="/" && method=="GET")
            {
                httpContext.Response.StatusCode = 200;
                await httpContext.Response.WriteAsync("<h1>No response</h1>");
                return;
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareValidacionExtensions
    {
        public static IApplicationBuilder UseMiddlewareValidacion(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareValidacion>();
        }
    }
}
