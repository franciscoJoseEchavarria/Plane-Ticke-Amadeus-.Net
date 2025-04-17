# Go4IT Amadeus API

📑 Índice
Descripción
Arquitectura
Tecnologías Utilizadas
Estructura del Proyecto
Configuración del Entorno
Ejecución del Proyecto
Uso de Swagger
Endpoints Principales
Autenticación
Base de Datos
Infraestructura en la Nube
Pruebas
Despliegue
Contribuciones
Licencia

## 📝 Descripción

Go4IT Amadeus API es un proyecto backend desarrollado en ASP.NET Core que proporciona servicios RESTful para gestionar usuarios, administradores, destinos y preguntas/respuestas en una plataforma de servicios de viaje. La API permite la autenticación de usuarios y administradores, así como el acceso a datos relacionados con destinos de viaje y cuestionarios interactivos.

## 🏗️ Arquitectura

El proyecto sigue una arquitectura en capas diseñada para maximizar la separación de responsabilidades, facilitar las pruebas y mejorar la mantenibilidad:

## Capas Principales:

1. Capa de Presentación: Controladores API que exponen los endpoints HTTP.
2. Capa de Servicios: Implementa la lógica de negocio y orquesta las operaciones.
3. Capa de Acceso a Datos: Repositorios que manejan la comunicación con la base de datos.
4. Capa de Modelos: Define las entidades y objetos de transferencia de datos (DTOs).

## Patrones de Diseño:
- Patrón Repositorio: Abstrae el acceso a datos y facilita los tests unitarios.
- Inyección de Dependencias: Desacopla componentes y mejora la testabilidad.
- Patrón Servicio: Encapsula la lógica de negocio en servicios específicos.

## 💻 Tecnologías Utilizadas
- Framework: ASP.NET Core 9.0
- Lenguaje: C#
- ORM: Entity Framework Core
- Base de Datos: PostgreSQL
- Autenticación: JWT (JSON Web Tokens)
- Documentación API: Swagger/OpenAPI
- Hashing de Contraseñas: BCrypt
- Infraestructura en la Nube: AWS (Amazon Web Services)
- CI/CD: GitHub Actions

## 📂 Estructura del Proyecto

```
go4it_amadeus/
│
├── Controllers/              # Controladores API
│   ├── AdminController.cs    # Gestión de administradores
│   ├── AuthController.cs     # Autenticación de usuarios
│   ├── DestinationController.cs  # Gestión de destinos
│   ├── UserController.cs     # Gestión de usuarios
│   └── ...
│
├── Models/                   # Modelos de datos
│   ├── Admin.cs              # Modelo de administrador
│   ├── User.cs               # Modelo de usuario
│   ├── Destination.cs        # Modelo de destino
│   ├── Question.cs           # Modelo de pregunta
│   ├── User_answers.cs       # Modelo de respuestas de usuario
│   ├── DTO/                  # Objetos de transferencia de datos
│   └── Exception/            # Modelos para manejo de excepciones
│
├── Services/                 # Servicios de negocio
│   ├── AdminService.cs       # Servicio para administradores
│   ├── AuthService.cs        # Servicio de autenticación
│   ├── AuthAdminService.cs   # Servicio de autenticación para administradores
│   ├── UserService.cs        # Servicio para usuarios
│   └── ...
│
├── Repositories/             # Repositorios de acceso a datos
│   ├── AdminRepository.cs    # Repositorio para administradores
│   ├── UserRepository.cs     # Repositorio para usuarios
│   ├── QuestionRepository.cs # Repositorio para preguntas
│   └── ...
│
├── ContractsService/         # Interfaces para servicios
│   ├── IAdminService.cs
│   ├── IUserService.cs
│   └── ...
│
├── ContractsRepository/      # Interfaces para repositorios
│   ├── IAdminRepository.cs
│   ├── IUserRepository.cs
│   └── ...
│
├── Data/                     # Configuración de la base de datos
│   └── AmadeusAPIDbContext.cs  # Contexto de EF Core
│
├── Migrations/               # Migraciones de EF Core
│
├── Properties/               # Configuración del proyecto
│   └── launchSettings.json   # Configuración de arranque
│
├── appsettings.json         # Configuración general
├── appsettings.Development.json  # Configuración de desarrollo
└── Program.cs               # Punto de entrada y configuración de la aplicación
```

##  Configuración del Entorno
Requisitos Previos
.NET SDK 9.0 o superior
Visual Studio 2022 (opcional)
Visual Studio Code (opcional)
PostgreSQL (opcional para desarrollo local)
Configuración Inicial

### 1. Clonar el repositorio:
sh
git clone https://github.com/tu-usuario/proyect-gp4it-.net.git
cd proyect-gp4it-.net/go4it_amadeus

### 2. Restaurar las dependencias:
sh
dotnet restore

### 3. Configurar la base de datos:

La aplicación está configurada para conectarse a una instancia de PostgreSQL en AWS RDS. Si deseas configurar una base de datos local para desarrollo, actualiza el archivo appsettings.Development.json:
sh
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=go4it;Username=tu_usuario;Password=tu_contraseña;"
}


### 4. Aplicar las migraciones:
sh
dotnet ef database update


## ▶️ Ejecución del Proyecto
Ejecutar con .NET CLI

### 1. Iniciar la aplicación:

dotnet run

### 2. Con Hot Reload activado (recomendado para desarrollo):

dotnet watch

La aplicación estará disponible en:

- HTTP: http://localhost:5177
- HTTPS: https://localhost:7157
- Swagger: https://localhost:7157/swagger (o http://localhost:5177/swagger)

## 📘 Uso de Swagger

Swagger proporciona una interfaz interactiva para explorar y probar la API. Para acceder a Swagger:

- Ejecuta la aplicación (como se explicó anteriormente)
- Abre tu navegador y navega a:

http://localhost:5177/swagger


Cómo Utilizar Swagger
1. Explorar Endpoints:

Los endpoints están agrupados por controladores (Admin, User, Destination, etc.)
Haz clic en cualquier endpoint para expandirlo y ver sus detalles

2. Autenticación:

Para endpoints protegidos, necesitarás autenticarte:
Obtén un token usando el endpoint /api/Auth/login o /api/Admin/login
Haz clic en el botón "Authorize" en la parte superior de la página
Ingresa tu token en el formato: Bearer tu_token_aquí
Haz clic en "Authorize"
Probar Endpoints:

Haz clic en "Try it out" en cualquier endpoint
Completa los parámetros requeridos
Haz clic en "Execute"
Verás la respuesta, incluyendo el código de estado y el cuerpo
Esquemas:

En la sección "Schemas" puedes ver la estructura de todos los modelos utilizados en la API

## 🔄 Endpoints Principales

### Administradores

| Método | Ruta                | Descripción                           |
| ------ | ------------------- | ------------------------------------- |
| GET    | /api/Admin          | Obtener todos los administradores     |
| GET    | /api/Admin/{id}     | Obtener un administrador por ID       |
| POST   | /api/Admin          | Crear un nuevo administrador          |
| PUT    | /api/Admin/{id}     | Actualizar un administrador existente |
| DELETE | /api/Admin/{id}     | Eliminar un administrador             |
| POST   | /api/Admin/login    | Autenticar un administrador           |

### Usuarios

| Método | Ruta                         | Descripción                           |
| ------ | ---------------------------- | ------------------------------------- |
| GET    | /api/User                    | Obtener todos los usuarios            |
| GET    | /api/User/GetById{id}        | Obtener un usuario por ID             |
| GET    | /api/User/GetEmail/{email}   | Obtener un usuario por email          |
| POST   | /api/User                    | Crear un nuevo usuario                |
| PUT    | /api/User/{id}               | Actualizar un usuario existente       |
| DELETE | /api/User/{id}               | Eliminar un usuario                   |

### Destinos

| Método | Ruta                           | Descripción                            |
| ------ | ------------------------------ | -------------------------------------- |
| GET    | /api/Destination               | Obtener todos los destinos             |
| GET    | /api/Destination/{id}          | Obtener un destino por ID              |
| POST   | /api/Destination               | Crear un nuevo destino                 |
| PUT    | /api/Destination/{id}          | Actualizar un destino existente        |
| DELETE | /api/Destination/{id}          | Eliminar un destino                    |

### Preguntas y Respuestas

| Método | Ruta                      | Descripción                         |
| ------ | ------------------------- | ----------------------------------- |
| GET    | /api/Question             | Obtener todas las preguntas         |
| GET    | /api/Question/{id}        | Obtener una pregunta por ID         |
| POST   | /api/Question             | Crear una nueva pregunta            |
| POST   | /api/User_answers         | Guardar respuestas de usuario       |

## 🔐 Autenticación

La API utiliza autenticación basada en JWT (JSON Web Tokens) para proteger los endpoints.

Flujo de Autenticación
Registro: Crear un usuario o administrador mediante los endpoints correspondientes.
Login: Autenticarse utilizando email y contraseña para obtener un token JWT.
Uso del Token: Incluir el token en las solicitudes subsiguientes en el encabezado Authorization con el formato: Bearer {token}.
Configuración JWT
La configuración JWT se encuentra en appsettings.json:

"Jwt": {
  "Key": "tu_clave_secreta_aquí",
  "Issuer": "go4it_amadeus",
  "Audience": "go4it_users",
  "ExpirationMinutes": 30
}

### Ejemplo de Login

el login para admin esta automaritamente configurado para que el email y la contraseña sean las sigueintes:

POST /api/Auth/login
Content-Type: application/json

{
  "email": "usuario@ejemplo.com",
  "password": "contraseña123"
}
