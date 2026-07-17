var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    //Ejercicio #1 : Operacion suma
    context.Response.Headers["Content-Type"] = "text/html";
    string path = context.Request.Path.ToString().ToLower();

    if (path == "/add")
    {
        if (context.Request.Query.ContainsKey("firstNumber") && context.Request.Query.ContainsKey("secondNumber")
        && context.Request.Query.ContainsKey("operator"))
        {
            int firstNumber = int.Parse(context.Request.Query["firstNumber"]);
            int secondNumber = int.Parse(context.Request.Query["secondNumber"]);
            string operacion = context.Request.Query["operator"] == "add" ? $"{firstNumber + secondNumber}" : "Operacion no valida!";

            await context.Response.WriteAsync($"<h1>Resultado: {operacion}</h1>");
        }
    }

    //Ejercicio #2 : Operacion Multiplicar
    if (path == "/multiply")
    {
        if (context.Request.Query.ContainsKey("firstNumber") &&
        context.Request.Query.ContainsKey("secondNumber") && context.Request.Query.ContainsKey("operator"))
        {
            int firstNumber = int.Parse(context.Request.Query["firstNumber"]);
            int secondNumber = int.Parse(context.Request.Query["secondNumber"]);
            string operacion = context.Request.Query["operator"].ToString().ToLower() == "multiply" ? $"{firstNumber * secondNumber}" : "Operacion no valida!";

            await context.Response.WriteAsync($"<h1>Resultado: {operacion}</h1>");
        }
    }

    //Ejercicio #3 : Sin operator
    if (path == "/failed")
    {

        if (context.Request.Query.ContainsKey("firstNumber") &&
        context.Request.Query.ContainsKey("secondNumber") && context.Request.Query.ContainsKey("operator"))
        {
            int firstNumber = int.Parse(context.Request.Query["firstNumber"]);
            int secondNumber = int.Parse(context.Request.Query["secondNumber"]);
            string operador = context.Request.Query["operator"].ToString().ToLower() ?? "";

            string operacion = (operador != "add" && operador != "multiply") ? "bad" : "good";
            if (operacion == "bad")
            {
                context.Response.StatusCode = 400;
                operacion = "Invalid input for 'operation'";
            }
            else operacion = "Operacion valida";

            await context.Response.WriteAsync($"<h1>Resultado: {operacion}</h1>");
        }
    }

    //Ejercicio #4 : Sin parametros
    if (path == "/failedall")
    {
        context.Response.StatusCode = 400;
        if (!context.Request.Query.ContainsKey("firstNumber"))
        {
            await context.Response.WriteAsync("<h1>Entrada no valida para 'firstNumber'</h1>\n");
        }
        if (!context.Request.Query.ContainsKey("secondNumber"))
        {
            await context.Response.WriteAsync("<h1>Entrada no valida para 'secondNumber'</h1>\n");
        }
        if (!context.Request.Query.ContainsKey("operator"))
        {
            await context.Response.WriteAsync("<h1>Entrada no valida para 'operator'</h1>\n");
        }
        if (context.Request.Query.ContainsKey("firstNumber") && context.Request.Query.ContainsKey("secondNumber")
        && context.Request.Query.ContainsKey("operator"))
        {
            if (context.Request.Query["operator"] != "add" && context.Request.Query["operator"] != "multiply")
            {
                await context.Response.WriteAsync("<h1>Operadores Invalidos!</h1>\n");
            }
            else
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("<h1>Operadores Validos!</h1>\n");
            }
        }
    }
});


app.Run();
