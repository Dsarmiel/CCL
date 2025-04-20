# CCL

Este proyecto está basado en la arquitectura limpia (Clean Architecture) y está estructurado en diferentes capas para promover la separación de responsabilidades, la mantenibilidad y la escalabilidad del software.

## 🚀 Cómo Ejecutar el Proyecto

A continuación, se detallan los pasos necesarios para ejecutar la aplicación:

### ⚙️ Requisitos Previos

Antes de comenzar, asegúrate de tener instalado lo siguiente en tu sistema:

- **.NET SDK:** La versión del SDK de .NET compatible con el proyecto. Puedes descargarla desde el sitio oficial de [.NET](https://dotnet.microsoft.com/download).
- **PostgreSQL:** Un servidor de base de datos PostgreSQL en ejecución.

### 💾 Configuración de la Base de Datos

1. **Abre tu herramienta de gestión de base de datos PostgreSQL.**
2. **Conéctate a tu servidor de PostgreSQL.**
3. **Asegúrate de tener una base de datos llamada `ccl` creada.** Si no existe, puedes crearla con el siguiente comando SQL:
   ```sql
   CREATE DATABASE ccl;

### 🛠️ Configuración de la Aplicación

1.  **Navega al directorio `CCL.API`:** Abre tu terminal o símbolo del sistema y dirígete a la carpeta `CCL.API` dentro del proyecto.
2.  **Edita `appsettings.json`:** Verifica o modifica la configuración de la aplicación en el archivo `appsettings.json`. La sección de conexión a la base de datos y la configuración JWT deberían ser similares a esto:

    ```json
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Port=5432;Database=ccl;Username=postgres;Password=123"
      },
      "JWT": {
        "Issuer": "http://localhost:5246",
        "Audience": "http://localhost:5246",
        "SigningKey": "mkasidu0e912837F2h4jAkbDajxcoai8du-298jsuai32857hsys618JSU-09213jlikQaSjabcam",
        "ExpirationDays": 7
      }
    }
    ```
## 📦 Precarga de Datos en la Base de Datos

Este proyecto requiere que la tabla `productos` tenga datos iniciales para poder realizar pruebas de entrada y salida de inventario.

Para ello, se incluye un script SQL que:

- Crea la tabla `productos` con los campos necesarios.
- Inserta 10 productos de prueba con cantidades predefinidas.

### 📝 Instrucciones

1. Abre tu herramienta de gestión de base de datos PostgreSQL (pgAdmin, DBeaver, `psql`, etc.).
2. Conéctate a la base de datos configurada en el proyecto.
3. Ejecuta el siguiente script:

CREATE TABLE productos (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    cantidad INTEGER NOT NULL
);

INSERT INTO productos (nombre, cantidad) VALUES 
('Mouse inalámbrico', 50),
('Teclado mecánico', 30),
('Monitor 24 pulgadas', 20),
('Laptop Dell Inspiron', 15),
('Memoria USB 32GB', 100),
('Disco Duro Externo 1TB', 25),
('Webcam HD', 40),
('Router WiFi', 18),
('Auriculares Bluetooth', 35),
('Silla ergonómica', 10);


> Este paso es **obligatorio antes de ejecutar la aplicación**, ya que la funcionalidad de movimiento de productos depende de que existan productos cargados previamente.

### 🔒 Autenticación de Endpoints de Productos

Los endpoints relacionados con la gestión de productos en esta API están protegidos mediante **Autenticación Básica (HTTP Basic Auth)**. Para acceder a estas funcionalidades, deberás proporcionar las siguientes credenciales en la cabecera de tus solicitudes HTTP:

Donde `<Base64EncodedCredentials>` se genera codificando en Base64 la concatenación del nombre de usuario y la contraseña, separados por dos puntos (`:`).

Para este proyecto, las credenciales predeterminadas para acceder a los endpoints de productos son:

* **Usuario:** `Admin`
* **Contraseña:** `ab123`

**Ejemplo de cómo generar las credenciales codificadas en Base64:**

### 🔑 Autenticación mediante Token JWT

Los endpoints de esta API, incluyendo los de gestión de productos, están protegidos y requieren un token JSON Web Token (JWT) válido para su acceso.

**Obtención del Token JWT:**

1.  Realiza una petición `POST` al endpoint `/auth/login` con las siguientes credenciales en el cuerpo de la solicitud (normalmente en formato JSON):

    ```json
    {
      "username": "Admin",
      "password": "ab123"
    }
    ```

2.  Si las credenciales son correctas, el servidor responderá con un token JWT en el cuerpo de la respuesta (la estructura exacta puede variar, pero comúnmente se incluye en un campo llamado `"token"`).

**Uso del Token JWT:**

Una vez que hayas obtenido el token JWT, deberás incluirlo en la cabecera `Authorization` de todas las solicitudes posteriores a los endpoints protegidos.

## 🧱 Estructura del Proyecto

### 📂 `CCL.API` - Capa de Presentación

Responsable de exponer los endpoints HTTP de la API.

- `Controllers/` – Controladores que manejan las solicitudes HTTP.
- `Program.cs` – Punto de entrada de la aplicación y configuración de servicios.
- `appsettings.json` – Archivo de configuración (cadena de conexión, claves, etc.).

### 📂 `CCL.Application` - Capa de Aplicación

Contiene la lógica de negocio y la implementación de los casos de uso.

- `DTOs/` – Objetos de transferencia de datos utilizados entre capas.
- `Mappers/` – Mapeos entre entidades del dominio y DTOs.
- `Services/` – Implementación de la lógica de negocio.
  - `Implementaciones/` – Implementaciones concretas de los servicios.
  - `Interfaces/` – Interfaces que definen los contratos de los servicios.
- `Validations/` – Validaciones para la entrada de datos y reglas de negocio.

### 📂 `CCL.Domain` - Capa de Dominio

Encapsula los modelos y reglas de negocio principales.

- `Entities/` – Entidades del dominio que representan el modelo de negocio.
- `Repositories/` – Interfaces que definen el contrato de acceso a datos.
- `Exceptions/` – Excepciones específicas del dominio.

### 📂 `CCL.Infrastructure` - Capa de Infraestructura

Encargada de la persistencia y detalles técnicos como el acceso a datos.

- `DB/` – Configuración del `DbContext` y migraciones de base de datos.
- `Repositories/` – Implementaciones concretas de los repositorios definidos en el dominio.

### 📂 `CCL.Shared` - Capa Compartida

Componentes reutilizables y utilitarios comunes para todas las capas.

- `Response/` – Modelos estándar de respuesta de la API.

## 🧩 Paquetes Instalados

Este proyecto utiliza las siguientes dependencias:

- `Newtonsoft.Json`  
- `Microsoft.AspNetCore.Mvc.NewtonsoftJson`  
- `Microsoft.EntityFrameworkCore` 
- `Npgsql.EntityFrameworkCore.PostgreSQL`
- `StyleCop.Analyzers`  
- `Microsoft.EntityFrameworkCore.Relational`  
- `Microsoft.EntityFrameworkCore.Design`  
- `Microsoft.AspNetCore.Authentication.JwtBearer`

---