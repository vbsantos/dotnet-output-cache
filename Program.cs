using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOutputCache(options =>
{
    options.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(5);
});

var app = builder.Build();

// Usando o Output Cache
app.UseOutputCache();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var apiGroup = app
    .MapGroup("/API")
    .CacheOutput();

var weatherGroup = apiGroup
    .MapGroup("/Weather")
    .WithTags("Weather")
    .WithOpenApi();

weatherGroup
    .MapGet("/WeatherForecast", ProcessWeatherForecast)
    .WithName("GetWeatherForecast");

app.Run();

static async Task<Results<Ok<WeatherForecast[]>, NotFound>> ProcessWeatherForecast()
{
    var summaries = new[]
    {
        "Freezing", "Bracing", "Chilly",
        "Cool", "Mild", "Warm", "Balmy",
        "Hot", "Sweltering", "Scorching"
    };

    var forecast = await Task.Run(() =>
    {
        return Enumerable
            .Range(1, 5)
            .Select(index => new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
    });

    return forecast is null or { Length: 0 }
        ? TypedResults.NotFound()
        : TypedResults.Ok(forecast);
}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
