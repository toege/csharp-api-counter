using api_counter.wwwapi8;
using api_counter.wwwapi8.Helpers;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

CounterHelper.Initialize();


//TODO: 1. write a method that returns all counters in the counters list.  use method below as a starting point
app.MapGet("GetAllCounters", () =>
{
    return Results.Ok();
});


//TODO: 2. write a method to return a single counter based on the id being passed in.  complete method below
app.MapGet("GetACounter/{id}", (int id) =>
{
    return Results.Ok(id);
});

//TODO: 3.  write another controlller method that returns counters that have a value greater than the {number} passed in.        
app.MapGet("greaterthan/{number}", (int number) =>
{
    return Results.Ok(number);
});


















var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
