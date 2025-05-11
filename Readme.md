# Homs Authentication Service

A clean architecture-based authentication service built with .NET 9 that manages user authentication and authorization.

## Project Overview

Homs.AuthService is designed as a microservice for handling all authentication and user management needs. It follows Clean Architecture principles to ensure separation of concerns, testability, and maintainability.

## Clean Architecture

This project strictly follows Clean Architecture principles with the following layers:

### Domain Layer (Homs.AuthService.Domain)

- Contains enterprise business rules and entities
- Has no dependencies on other project layers or external frameworks
- Includes core domain entities like `User`

### Application Layer (Homs.AuthService.Application)

- Contains business rules specific to the application
- Defines interfaces that are implemented by outside layers
- Includes DTOs, interfaces, and service definitions
- Depends only on the Domain layer

### Infrastructure Layer (Homs.AuthService.Infrastructure)

- Contains implementations of the interfaces defined in the Application layer
- Manages database access, external APIs, and other external concerns
- Includes the EF Core DbContext, migrations, and service implementations
- Depends on the Application and Domain layers

### API Layer (Homs.AuthService.API)

- Contains controllers and API configuration
- Serves as the entry point to the application
- Depends on all other layers

## Project Structure

```
Homs.AuthService/
├── Homs.AuthService.API/             # Web API
│   ├── Controllers/                  # API Controllers
│   └── Program.cs                    # Application entry point
├── Homs.AuthService.Application/     # Application logic
│   ├── DTOs/                         # Data Transfer Objects
│   ├── Interfaces/                   # Service interfaces
│   └── Services/                     # Service implementations
├── Homs.AuthService.Domain/          # Domain entities
│   └── Entities/                     # Domain models
└── Homs.AuthService.Infrastructure/  # External concerns
    ├── Data/                         # Database context
    ├── Migrations/                   # EF Core migrations
    └── Services/                     # Service implementations
```

## Setup and Installation

### Prerequisites

- .NET 9 SDK
- PostgreSQL database server

### Database Configuration

The application is configured to use PostgreSQL. You can modify the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=HomsAuthServiceDb;Username=postgres;Password=yourpassword"
}
```

## Running the Application

### Using Visual Studio

1. Open the solution file `Homs.AuthService.sln` in Visual Studio
2. Ensure PostgreSQL is running and the connection string in `appsettings.json` is correct
3. Right-click on the `Homs.AuthService.API` project in Solution Explorer and select "Set as Startup Project"
4. Press F5 or click the "Start Debugging" button (green play icon) in the toolbar
5. Visual Studio will build the project, apply any pending migrations, and launch the API in your default browser with Swagger UI

### Using Visual Studio Code

1. Open the project folder in Visual Studio Code
2. Ensure PostgreSQL is running and the connection string in `appsettings.json` is correct
3. Open a terminal in VS Code (Terminal > New Terminal)
4. Navigate to the API project directory:
   ```
   cd Homs.AuthService.API
   ```
5. Run the application:
   ```
   dotnet run
   ```
6. Open your browser and navigate to `https://localhost:5001` or `http://localhost:5000` (check the terminal output for the exact URL)

The application automatically applies any pending migrations on startup regardless of which IDE you use.

### Using Command Line

1. Open a command prompt or terminal
2. Ensure PostgreSQL is running and the connection string in `appsettings.json` is correct
3. Navigate to the API project directory:
   ```
   cd Homs.AuthService.API
   ```
4. Run the application:
   ```
   dotnet run
   ```
5. Open your browser and navigate to the URL displayed in the terminal output

## API Endpoints

### Users

- `GET /api/users` - Get all users
- `GET /api/users/{id}` - Get a user by ID
- `POST /api/users` - Create a new user

## Development

### Adding Migrations

To add a new migration:

```bash
cd Homs.AuthService.Infrastructure
dotnet ef migrations add MigrationName --startup-project ../Homs.AuthService.API
```

### Updating the Database

To apply migrations manually:

```bash
cd Homs.AuthService.Infrastructure
dotnet ef database update --startup-project ../Homs.AuthService.API
```

## Security Notes

In this project template, password hashing is commented out and should be implemented properly in a production environment.