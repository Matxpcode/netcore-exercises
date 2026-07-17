
namespace MiddlewareExample.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        //Implementa la interfaz IMiddleware
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Ida del Middleware 2 - Externo\n");
            await next(context);
            await context.Response.WriteAsync("Vuelta del Middleware 2 - Externo\n");
        }
    }

    //Custom middleware extension
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
          
    }
}
