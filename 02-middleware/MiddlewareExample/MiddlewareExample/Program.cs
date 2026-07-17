using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

//Registramos nuestra clase middleware personalizada como servicio
//builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

//Middleware 1
app.Use(async(HttpContext context,RequestDelegate next) => {
    await context.Response.WriteAsync("Ida en middleware 1\n");
    await next(context);
    await context.Response.WriteAsync("Vuelta en middleware 1\n");
});

//Middleware 2 (antiguo)
//app.Use(async(HttpContext context, RequestDelegate next) =>{
//    await context.Response.WriteAsync("Ida en middleware 2\n");
//    await next(context);
//    await context.Response.WriteAsync("Vuelta en middleware 2\n");
//});

//Middleware 2 (middleware personalizado externo)
//app.UseMiddleware<MyCustomMiddleware>();
//app.UseMyCustomMiddleware();
app.UseHelloCustomMiddleware();

//Middleware 3 - Middleware terminal - cambiado a Run como punto de retorno
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Middleware terminal\n");
});

app.Run();
