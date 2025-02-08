# ServiceLifetimes

This project is a simple ASP.NET Core web application that demonstrates the use of different service lifetimes (transient, scoped, and singleton) in dependency injection. The application includes a welcome service that generates a welcome message with a unique service ID and creation timestamp. The project is containerized using Docker, with a `Dockerfile` and `compose.yaml` file provided for building and running the application in a Docker container.

## Key Parts

- **ServiceLifetimes/Services/IWelcomeService.cs**: Defines the `IWelcomeService` interface.
- **ServiceLifetimes/Services/WelcomeService.cs**: Implements the `IWelcomeService` interface.
- **ServiceLifetimes/Program.cs**: Configures the web application, registers services, and defines request handling logic.
- **ServiceLifetimes/Dockerfile**: Dockerfile for building the application image.
- **compose.yaml**: Docker Compose file for running the application container.
- **ServiceLifetimes/Properties/launchSettings.json**: Configuration for launching the application during development.

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker](https://www.docker.com/get-started)

### Building and Running the Application

1. Clone the repository:
    ```sh
    git clone https://github.com/Diegoalru/ServiceLifetimes.git
    cd ServiceLifetimes
    ```

2. Build and run the application using Docker Compose:
    ```sh
    docker-compose up --build
    ```

3. The application will be available at `http://localhost:8080`.

### Endpoints

- **GET /**: Returns welcome messages from two instances of `IWelcomeService`.
- **GET /about**: Returns a static message about the site.
