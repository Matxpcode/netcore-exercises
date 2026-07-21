using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FoodFlow
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class PedidosMiddleware
    {
        private readonly RequestDelegate _next;

        public PedidosMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            //1.Extraemos el path y el method
            string path = httpContext.Request.Path.ToString().ToLower();
            string method = httpContext.Request.Method;

            if (path=="/" && method=="POST")
            {
                //2.Leemos la cabecera personalizada "X-Delivery-Token"
                string tokenRecibido = httpContext.Request.Headers["X-Delivery-Token"].ToString();

                //3.Evaluamos si el token es correcto
                if (tokenRecibido!="RepartidorActivo2026")
                {
                    //Generamos
                }



            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class PedidosMiddlewareExtensions
    {
        public static IApplicationBuilder UsePedidosMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PedidosMiddleware>();
        }
    }
}
