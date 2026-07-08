var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context) =>
{
    //Ejercicio 1: Manipulación explícita del código de estado (HTTP Status Code)
    // Determina el resultado de la transacción antes de enviar datos al cliente.

    //if (1 == 1)
    //{
    //    context.Response.StatusCode = 200;
    //}
    //else
    //{
    //    context.Response.StatusCode=400;
    //}

    // Ejercicio 2: Inspección de rutas de red y asignación de metadatos (Headers)

    //string path = context.Request.Path;
    //string method = context.Request.Method;

    //context.Response.Headers["MyKey"] = "my value";
    //context.Response.Headers["Server"] = "My server";
    //context.Response.Headers["Content-Type"] = "text/html";

    //await context.Response.WriteAsync("<h1>Hello</h1>");
    //await context.Response.WriteAsync("<h2>World</h2>");
    //await context.Response.WriteAsync($"<p>{path}</p>");
    //await context.Response.WriteAsync($"<p>{method}</p>");


    // Ejercicio 3: Enrutamiento lógico y validación estructural de Query Strings
    // Filtra las peticiones de tipo GET que contienen argumentos clave en la URL.

    //context.Response.Headers["Content-type"] = "text/html";
    //if (context.Request.Method == "GET")
    //{
    //    if (context.Request.Query.ContainsKey("id"))
    //    {
    //        string id = context.Request.Query["id"];
    //        await context.Response.WriteAsync($"<p>{id}</p>");
    //    }
    //}

    // Ejercicio 4: Extracción de metadatos del cliente (User-Agent)
    // Analiza la cabecera enviada por el navegador para identificar el entorno/S.O.

    //context.Response.Headers["Content-type"] = "text/html";
    //if (context.Request.Headers.ContainsKey("User-Agent"))
    //{
    //    string userAgent = context.Request.Headers["User-Agent"];
    //    await context.Response.WriteAsync($"<p>{userAgent}</p>");
    //}


    // CASOS PRÁCTICOS: MANEJO DE PATHS PERSONALIZADOS Y RENDERIZADO DINÁMICO

    // CASO 1: Enrutamiento manual (Mapeo de Rutas y códigos de error controlados)

    //context.Response.Headers["Content-Type"] = "text/html; charset=utf-8";
    //string path = context.Request.Path.ToString().ToLower();

    //if (path == "/")
    //{
    //    //Usamos boostrap integrado mediante CDN en el HTML
    //    await context.Response.WriteAsync(@"
    //        <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB"" crossorigin=""anonymous"">
    //        <div class = 'container mt-5'>
    //            <div class = 'alert alert-primary text-center'>
    //                <h1>!Bienvenido a mi Servidor Core¡</h1>
    //                <p>Estas en la pagina de inicio corporativa.</p>
    //                <a href='/contacto' class='btn btn-outline-primary'>Ir a Contacto</a>
    //            </div>
    //        </div>
    //    ");
    //}
    //else if (path == "/contacto")
    //{
    //    await context.Response.WriteAsync(@"
    //        <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB"" crossorigin=""anonymous"">
    //        <div class = 'container mt-5'>
    //           <h1>!Contacto de Soporte¡</h1>
    //           <p>Escribenos a: soporte@cibertec.edu.pe</p>
    //           <a href='/' class='btn btn-secondary'>Regresar</a>
    //        </div>
    //    ");
    //}
    //else
    //{
    //    //Si escribe cualquier otra cosa, forzamos el codigo 404 en el Network
    //    context.Response.StatusCode = 404;
    //    await context.Response.WriteAsync(@"
    //        <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB"" crossorigin=""anonymous"">
    //        <h1 class='text-danger text-center mt-5'>404 - Pagina no encontrada</h1>
    //    ");
    //}

    // CASO 2: Procesamiento de parámetros y evaluación de lógica de negocio

    context.Response.Headers["Content-Type"] = "text/html; charset=utf-8";
    if (context.Request.Query.ContainsKey("nombre") && context.Request.Query.ContainsKey("nota"))
    {
        string alumno = context.Request.Query["nombre"];
        int nota = int.Parse(context.Request.Query["nota"]);

        string claseBoostrap = nota >= 13 ? "alert-success" : "alert-danger";
        string resultado = nota >= 13 ? "APROBADO" : "DESAPROBADO";

        await context.Response.WriteAsync($@"
        <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB' crossorigin='anonymous'>

        <div class='container mt-5'>
            <div class='alert {claseBoostrap}'>
                <h3>Alumno: {alumno}</h3>
                <p>Nota final: <strong>{nota}</strong></p>
                <hr>
                <h4>Estado: {resultado}</h4>
            </div>
        </div>
        ");
    }
    else
    {
        await context.Response.WriteAsync(@"
            <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css' rel='stylesheet'>
            <p>Por favor envia los parametros: <code>?nombre=Mateo&amp;nota=15</code> en la URL</p>");
    }

});

app.Run();
