# 📁 Sección 1: Fundamentos del Protocolo HTTP

Este directorio contiene los laboratorios prácticos correspondientes al
**Tema 1** del curso, enfocado en la manipulación nativa del protocolo 
HTTP. Los ejercicios demuestran cómo interactuar con la tarta de red
a través del objeto `HttpContext` en **.NET Core**, analizando el flujo
de peticiones y respuestas directamente desde el servidor Kestrel.

---

## 🛠️ Stack Tecnológico de la Sección

* **Ecosistema Backend:** .NET Core 8.0 / C#
* **Servidor Web Embebido:** Kestrel
* **Maquetación e Interfaz:** HTML5 / Bootstrap 5.3 (CDN)
* **Entorno de Análisis:** Herramientas de Desarrollador (Pestaña Network)

---

## 📖 Prácticas y Ejercicios

### Módulo 1: Teoría Base de Protocolo

#### Ejercicio 1: Modificación del Estado del Response
* **Objetivo:** Controlar manualmente las respuestas del servidor.
* **Explicación:** Se manipula la propiedad `context.Response.StatusCode`.
  Permite forzar códigos de éxito (`200 OK`) o errores controlados
  por lógica (`400 Bad Request`), enseñando al navegador cómo 
  interpretar el resultado antes de leer los datos finales.

#### Ejercicio 2: Manejo y Asignación de Claves (Headers)
* **Objetivo:** Leer datos de entrada de la red y responder metadatos.
* **Explicación:** Captura propiedades estructurales de la petición
  (`Path` y `Method`) y escribe cabeceras personalizadas de salida
  utilizando el diccionario de datos de `Response.Headers`.

#### Ejercicio 3: Validación de Métodos y Parámetros con Query Strings
* **Objetivo:** Filtrar el comportamiento según variables de la URL.
* **Explicación:** Se valida si el verbo HTTP entrante es un `GET`.
  De ser correcto, el servidor analiza mediante `Query.ContainsKey()`
  si el cliente inyectó argumentos específicos (ej. `?id=10`)
  para proceder a procesarlos de forma aislada.

#### Ejercicio 4: Verificación del Cliente con User-Agent
* **Objetivo:** Leer metadatos de identidad del navegador.
* **Explicación:** Se accede directamente a la cabecera interna de
  la petición `User-Agent`. Permite recuperar la cadena histórica
  del cliente para descifrar qué navegador web y sistema operativo
  dispararon la solicitud original.

---

### Módulo 2: Casos Prácticos y Control de Flujo

#### Caso 1: Enrutamiento Manual y Páginas Personalizadas
* **Objetivo:** Simular un motor de ruteo dinámico a bajo nivel.
* **Explicación:** Evaluando la propiedad `context.Request.Path`, el
  servidor divide el tráfico. Si se solicita la raíz `/` o el segmento
  `/contacto`, despacha vistas HTML con estilos Bootstrap. Cualquier 
  otra ruta no registrada genera un código `404 Not Found`.

#### Caso 2: Procesamiento de Reglas de Negocio en la URL
* **Objetivo:** Capturar variables, aplicar lógica y renderizar alertas.
* **Explicación:** El bloque valida la presencia simultánea de parámetros
  de consulta (`nombre` y `nota`). Procesa las variables aplicando un
  operador ternario para definir alertas de Bootstrap (`alert-success` 
  o `alert-danger`). Incorpora el uso seguro de Entidades HTML 
  (`&amp;`) en las cadenas de contingencia.

---
