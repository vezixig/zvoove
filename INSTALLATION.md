# Installation Guide

This guide provides comprehensive instructions for setting up and running the zvoove application, which consists of an Angular frontend and a .NET 9 backend.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Development Setup (IDE)](#development-setup-ide)
- [Docker Setup](#docker-setup)
- [Environment Configuration](#environment-configuration)
- [Troubleshooting](#troubleshooting)

## Prerequisites

### For Development Setup

- **Node.js** (version 18.x or higher) - [Download here](https://nodejs.org/)
- **npm** (comes with Node.js)
- **Angular CLI** (version 19.x or higher)
- **.NET 9 SDK** - [Download here](https://dotnet.microsoft.com/download/dotnet/9.0)
- **Git** - [Download here](https://git-scm.com/)
- **IDE/Editor** (Visual Studio, Visual Studio Code, JetBrains Rider, etc.)

### For Docker Setup

- **Docker Desktop** - [Download here](https://www.docker.com/products/docker-desktop/)
- **Git** - [Download here](https://git-scm.com/)

## Development Setup (IDE)

### 1. Clone the Repository

```bash
git clone https://github.com/vezixig/zvoove.git
cd zvoove
```

### 2. Backend Setup (.NET 9)

#### Navigate to Backend Directory

```bash
cd Backend/Backend/Backend
```

#### Restore Dependencies

```bash
dotnet restore
```

#### Build the Project

```bash
dotnet build
```

#### Run the Backend

```bash
dotnet run
```

The backend will start on `https://localhost:7199` by default.

#### Alternative: Run from IDE

- Open `Backend/Backend/Backend.sln` in Visual Studio or your preferred IDE
- Set `Backend` as the startup project
- Press F5 or click Run

### 3. Frontend Setup (Angular)

#### Navigate to Frontend Directory

```bash
cd Frontend
```

#### Install Dependencies

```bash
npm install --f
```

#### Install Angular CLI (if not already installed)

```bash
npm install -g @angular/cli
```

#### Start Development Server

```bash
ng serve
```

The frontend will start on `http://localhost:4200` by default.

#### Alternative: Run from IDE

- Open the `Frontend` folder in your IDE
- Run the npm start script or use `ng serve` command

### 4. Verify Installation

1. Open your browser and navigate to `http://localhost:4200`
2. The frontend should load and be able to communicate with the backend API
3. Check the browser's developer console for any errors

## Docker Setup

### 1. Clone the Repository

```bash
git clone https://github.com/vezixig/zvoove.git
cd zvoove
```

### 2. Build and Run Backend with Docker

#### Navigate to Backend Directory

```bash
cd Backend/Backend
```

#### Build Backend Docker Image

```bash
docker build -t backend:latest .
```

#### Run Backend Container

```bash
docker run -d --name zvoove-backend -p 8081:8081 backend:latest
```

The backend will be available at `https://localhost:8081`

### 3. Build and Run Frontend with Docker

#### Navigate to Frontend Directory

```bash
cd ../../Frontend
```

#### Build Frontend Docker Image

```bash
docker build -t frontend:latest .
```

#### Run Frontend Container

```bash
docker run -d --name zvoove-frontend -p 80:80 frontend:latest
```

The frontend will be available at `http://localhost`

### 4. Docker Compose (Recommended)

For easier management, you can create a `docker-compose.yml` file in the root directory:

```yaml
version: "3.8"

services:
  backend:
    build:
      context: ./Backend/Backend
      dockerfile: Dockerfile
    ports:
      - "8081:8081"
    environment:
      - ASPNETCORE_ENVIRONMENT=Production
      - ASPNETCORE_URLS=https://+:8081
    networks:
      - zvoove-network

  frontend:
    build:
      context: ./Frontend
      dockerfile: Dockerfile
    ports:
      - "80:80"
    depends_on:
      - backend
    networks:
      - zvoove-network

networks:
  zvoove-network:
    driver: bridge
```

#### Run with Docker Compose

```bash
# Build and start all services
docker-compose up --build

# Run in detached mode
docker-compose up -d --build

# Stop services
docker-compose down
```

## Environment Configuration

### Backend Configuration

The backend uses the following configuration files:

- `appsettings.json` - Production settings
- `appsettings.Development.json` - Development settings

### Frontend Configuration

The frontend uses environment files located in `src/environments/`:

- `environment.ts` - Development environment
- `environment.prod.ts` - Production environment

Update the API base URL in these files to match your backend configuration.

## API Endpoints

The backend provides the following main endpoints:

- **Health Check**: `GET /health` (if implemented)
- **Repository Search**: Check the backend code for specific API endpoints
- **OpenAPI Documentation**: Available via Scalar UI when running in development mode

### Accessing API Documentation

The backend uses **Scalar** to provide interactive OpenAPI documentation. When running the backend in development mode:

1. **Start the backend** following the instructions above
2. **Navigate to** `https://localhost:7199/scalar/v1` (development) or `https://localhost:8081/scalar/v1` (Docker)
3. **Explore the API** using the interactive Scalar interface

Scalar provides a modern, user-friendly interface for exploring and testing the API endpoints, making it easy to understand the available endpoints, request/response schemas, and test API calls directly from the browser.

## Troubleshooting

### Common Development Issues

#### Backend Issues

1. **Port Already in Use**

   - Change the port in `launchSettings.json`
   - Or kill the process using the port: `netstat -ano | findstr :7199`

2. **Certificate Issues**

   - Trust the development certificate: `dotnet dev-certs https --trust`

3. **Dependencies Not Found**
   - Run `dotnet restore` in the Backend/Backend/Backend directory

#### Frontend Issues

1. **Node Modules Issues**

   - Delete `node_modules` folder and `package-lock.json`
   - Run `npm install` again

2. **Angular CLI Not Found**

   - Install globally: `npm install -g @angular/cli`

3. **Port Already in Use**
   - Use a different port: `ng serve --port 4201`

### Docker Issues

1. **Build Failures**

   - Ensure Docker Desktop is running
   - Check Dockerfile syntax
   - Clear Docker cache: `docker system prune`

2. **Container Not Starting**

   - Check container logs: `docker logs <container-name>`
   - Verify port mappings

3. **Network Issues**
   - Ensure containers are on the same network when using Docker Compose
   - Check firewall settings

### Performance Tips

1. **Development**

   - Use `ng build --watch` for automatic rebuilds
   - Enable hot reload for faster development

2. **Docker**
   - Use multi-stage builds for smaller production images
   - Leverage Docker layer caching

## Additional Resources

- [Angular Documentation](https://angular.io/docs)
- [.NET 9 Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [Docker Documentation](https://docs.docker.com/)
- [PrimeNG Documentation](https://primeng.org/) (UI components used in frontend)
