# Minimal API with Output Caching

This project demonstrates a minimal API in ASP.NET Core, focusing on delivering weather forecast data. Utilizing Output Caching, it aims to enhance performance by caching responses, reducing load times for subsequent requests. It's an excellent starting point for understanding Minimal APIs and caching mechanisms in ASP.NET Core.

## Features

- **Minimal API Setup**: A straightforward approach to creating web APIs with less boilerplate code.
- **Swagger Integration**: Easy API exploration and testing with Swagger UI.
- **Output Caching**: Implements Output Caching to improve response times and reduce server load.
- **Grouped Routes**: Organized API endpoints into logical groups for better management and clarity.

## Getting Started

To get the project up and running on your local machine, follow these steps:

1. **Clone the repository**:
   ```sh
   git clone <repository-url>
   ```

2. **Navigate to the project directory**:
   ```sh
   cd <project-directory>
   ```

3. **Build and run the project**:
   - Using the dotnet CLI:
     ```sh
     dotnet run
     ```
   - Using Visual Studio:
     Open the solution file and run the project using IIS Express.

## Exploring the API

Once the application is running, navigate to `https://localhost:<port>/swagger` to view the Swagger UI, where you can test the API endpoints.

## API Endpoints

- **GET `/API/Weather/WeatherForecast`**: Fetches a 5-day weather forecast. Responses are cached for 5 seconds to demonstrate Output Caching.

## Technologies Used

- ASP.NET Core Minimal APIs
- Swagger/OpenAPI for API documentation
- Output Caching Middleware

## Project Structure

- `Program.cs`: The entry point of the application, where services are configured, and API endpoints are defined.
