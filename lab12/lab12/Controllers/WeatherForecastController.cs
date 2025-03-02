using lab12.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace lab12.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet]
    public IActionResult AddTable()
    {
        AppDbContext db = new AppDbContext(); //������� ��������� ���� ������, �����������
        Table table = new Table { Name = "Niel" }; //����������� ������ ������� �� ��������� �������
        db.Character.Add(table); //���������
        db.SaveChanges(); //��������� ���������
        return Ok();
    }
    [HttpGet]
    public IActionResult GetTable()
    {
        AppDbContext db = new AppDbContext(); //������� ��������� ���� ������, �����������
        var d = db.Character.ToList();
        return Ok(d);
    }
}
