# Desafío de Middlewares Personalizados en ASP.NET Core

Este proyecto implementa un sistema de control de flujo y seguridad perimetral mediante el uso de **Middlewares personalizados por convención** en .NET. El objetivo principal es interceptar, evaluar y responder de forma centralizada a peticiones de autenticación en la ruta raíz (`/`) antes de que impacten en las capas internas de la aplicación.

---

## 🚀 Tecnologías y Conceptos Utilizados

*   **.NET 8.0 / .NET 9.0 (ASP.NET Core Web API)**
*   **Middleware por Convención (Singleton por defecto):** Estructurado con un patrón de diseño basado en reflexión, optimizando el rendimiento al instanciarse una única vez al arrancar el servidor.
*   **Pipeline HTTP (Tubería de ejecución):** Manipulación directa del flujo de entrada (`Ida`) y salida (`Vuelta`) utilizando `RequestDelegate` y `HttpContext`.
*   **Control Lógico de Cortocircuitos (Short-circuiting):** Mecanismo para detener la propagación de la petición hacia el resto de la tubería cuando no cumple con las políticas de validación.

---

## 📋 Casos de Prueba Implementados

El middleware procesa de forma secuencial y jerárquica los siguientes escenarios de control para peticiones HTTP:

### 🟩 1. Acceso Exitoso (POST)
*   **Condición:** Credenciales correctas y completas.
*   **Entrada:** `email=admin@example.com&password=admin1234`
*   **Estado HTTP:** `200 OK`
*   **Salida (text/plain):** `Successful login`

<img width=50% alt="pregunta1_middleware" src="https://github.com/user-attachments/assets/60137455-db2b-4a87-883f-233ab3beecda" />

### 🟥 2. Credenciales Incorrectas (POST)
*   **Condición:** Estructura de formulario correcta, pero datos inválidos.
*   **Entrada:** `email=manager@example.com&password=manager-password`
*   **Estado HTTP:** `400 Bad Request`
*   **Salida (text/plain):** `Invalid login`

<img width=50% alt="pregunta2_middleware" src="https://github.com/user-attachments/assets/dded34ff-325f-4f53-a530-92bcf0b556c3" />

### 🟥 3. Cuerpo de Petición Vacío (POST)
*   **Condición:** Envío de una petición `POST` sin datos o sin cabeceras de formulario (`!HasFormContentType`).
*   **Entrada:** `[Cuerpo vacío]`
*   **Estado HTTP:** `400 Bad Request`
*   **Salida (text/plain):**
    ```text
    Invalid input for 'email'
    Invalid input for 'password'
    ```

<img width=50% alt="pregunta3_middleware" src="https://github.com/user-attachments/assets/ecda68a4-2fba-4ded-abc9-5bb77190ba65" />

### 🟥 4. Contraseña Omitida (POST)
*   **Condición:** Se envía el correo pero el campo de la contraseña está ausente o vacío.
*   **Entrada:** `email=test@example.com`
*   **Estado HTTP:** `400 Bad Request`
*   **Salida (text/plain):** `Invalid input for 'password'`

<img width=50% alt="pregunta4_middleware" src="https://github.com/user-attachments/assets/8ecf6be0-69ec-4ec2-9fdb-600c0bb2d1a5" />

### 🟥 5. Correo Omitido (POST)
*   **Condición:** Se envía la contraseña pero el campo del correo está ausente o vacío.
*   **Entrada:** `password=1234`
*   **Estado HTTP:** `400 Bad Request`
*   **Salida (text/plain):** `Invalid input for 'email'`

<img width=50% alt="pregunta5_middleware" src="https://github.com/user-attachments/assets/49d71b67-6cfd-4b0f-a71e-0120778cc643" />

### 🟦 6. Consulta de Estado (GET)
*   **Condición:** Petición de lectura del navegador en la raíz del servidor.
*   **Entrada:** N/A (Método `GET`)
*   **Estado HTTP:** `200 OK`
*   **Salida (text/plain):** `No response`

<img width=50% alt="pregunta6_middleware" src="https://github.com/user-attachments/assets/6f216d19-ecdc-40cd-beea-ed7a0197faf5" />

---

## 🛠️ Arquitectura del Pipeline (`Program.cs`)

Para evitar conflictos de renderizado en el navegador (errores `HTTP 404`) y garantizar la modularidad del código, se extendió `IApplicationBuilder` mediante un método de extensión limpio:

```csharp
using DesafioMiddleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Inyección del componente en la tubería HTTP
app.UseMiddlewareValidacion();

app.Run();
