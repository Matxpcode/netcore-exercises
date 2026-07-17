# 📁 Enrutamiento Modular y Reglas de Negocio en Query Strings

Este directorio contiene los laboratorios prácticos enfocados en el
aislamiento de flujos mediante rutas personalizadas independientes. El
objetivo es interactuar directamente con `HttpContext` para evaluar la 
propiedad `Path` en minúsculas y bifurcar el tráfico hacia bloques de 
código dedicados (`/add`, `/multiply`, `/failed`, `/failedall`).

---

## 🛠️ Stack Tecnológico de la Sección

* **Ecosistema Backend:** .NET Core 8.0 / C#
* **Servidor Web Embebido:** Kestrel
* **Maquetación e Interfaz:** HTML5 / Bootstrap 5.3 (CDN)
* **Entorno de Análisis:** Herramientas de Desarrollador / Postman

---

## 📖 Prácticas y Ejercicios

### Módulo 1: Procesamiento y Aritmética Modular

#### Ejercicio 1: Ruta Dedicada para Operación de Suma (`/add`)
* **Objetivo:** Construir un endpoint fijo para cálculos aditivos.
* **Explicación:** El bloque valida que la ruta sea exactamente `/add`
  y que las claves `firstNumber`, `secondNumber` y `operator` existan.
  Convierte las cadenas a enteros (`int.Parse`), realiza la suma y 
  renderiza el resultado usando contenedores y etiquetas HTML.

<img width=50% alt="tema2_netcore" src="https://github.com/user-attachments/assets/6f8397fc-943f-4818-9497-fed9cbffbdd2" />

#### Ejercicio 2: Ruta Dedicada para Operación de Multiplicación (`/multiply`)
* **Objetivo:** Aislar operaciones matemáticas complejas en su propia URL.
* **Explicación:** Actúa como un controlador independiente para la ruta
  `/multiply`. Inspecciona la Query String y condiciona la ejecución 
  mediante un operador ternario, asegurando que el cálculo solo se 
  despache si el operador web coincide estrictamente con el texto esperado.

<img width=50% alt="tema2_netcore_2" src="https://github.com/user-attachments/assets/676ff7ad-b16e-42e4-8fea-93b0f909a4c7" />

---

### Módulo 2: Control de Errores y Validación Estricta

#### Ejercicio 3: Intercepción de Operadores Inválidos (`/failed`)
* **Objetivo:** Detectar inconsistencias semánticas en los argumentos.
* **Explicación:** Si el cliente envía los datos pero ingresa un valor 
  erróneo en el operador (ej. `?operator=algo`), el sistema altera 
  manualmente el ciclo de vida de la red asignando el código de estado 
  `400 Bad Request` y sobrescribe la salida con un mensaje técnico.

<img width=50% alt="tema2_netcore_3" src="https://github.com/user-attachments/assets/08ac06fa-b7cd-4a79-bd1b-b330b375e508" />

#### Ejercicio 4: Reporte Independiente de Ausencia de Parámetros (`/failedall`)
* **Objetivo:** Auditar y notificar la omisión de variables de entrada.
* **Explicación:** Al acceder a `/failedall`, el servidor fuerza un 
  estado `400`. Mediante condicionales de negación (`!`) independientes, 
  revisa cada clave de la consulta y le imprime al usuario un reporte 
  línea por línea detallando específicamente qué datos olvidó enviar.

<img width=50% alt="tema2_netcore_4" src="https://github.com/user-attachments/assets/5c909e4e-d074-4576-8782-341ffef4a3ed" />

---
