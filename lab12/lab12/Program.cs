using lab12.Model;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(); //добавляем внедрение зависимостей
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1"); //подключаем Swagger
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Map("/about/{name}", (string name) => $"About the game {name}"); //добавляем маршрутизацию

app.Map("/news/{id:int}", (int id) => $"News: {id}"); //работа с параметрами

app.Map("{id=8}/{name=Aaron}", (int id, string name) => $"Forum: {id}\nName: {name}");

app.Run();

public class AtributTestController : Controller
{
    [Route("/news/{id:int}/{name:maxlength(6)}")]
    public string Person(int id, string name)
    {
        return $"ID: {id}\nName: {name}";
    }
}
