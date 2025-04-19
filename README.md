# CCL 

Este proyecto está basado en la arquitectura limpia (Clean Architecture) y está estructurado en diferentes capas para promover la separación de responsabilidades, la mantenibilidad y la escalabilidad del software.

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

### 📂 `CCL.Infrastructure` - Capa de Infraestructura

Encargada de la persistencia y detalles técnicos como el acceso a datos.

- `DB/` – Configuración del `DbContext` y migraciones de base de datos.
- `Repositories/` – Implementaciones concretas de los repositorios definidos en el dominio.

### 📂 `CCL.Shared` - Capa Compartida

Componentes reutilizables y utilitarios comunes para todas las capas.

- `Response/` – Modelos estándar de respuesta de la API.
- `Utils/` – Clases utilitarias y helpers generales.

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