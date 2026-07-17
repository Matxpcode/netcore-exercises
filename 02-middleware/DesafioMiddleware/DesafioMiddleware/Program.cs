using DesafioMiddleware;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

//Middleware : Personalizado por convencion 
app.UseMiddlewareValidacion();


app.Run();
