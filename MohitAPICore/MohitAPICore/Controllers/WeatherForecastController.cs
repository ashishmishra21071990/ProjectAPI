using Microsoft.AspNetCore.Mvc;
using MohitAPICore.Models;

namespace MohitAPICore.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> listemp = new List<Employee>() {
                new Employee() { EID = 101, Name = "Rohit", Age = 19, MobileNo = "7686868", City = "Noida", Post = "SE", Salary = 64777 },
                new Employee() { EID = 102, Name = "Kunal", Age = 29, MobileNo = "9086868", City = "Delhi", Post = "TL", Salary = 23777 },
                new Employee (){ EID = 103, Name = "Arun", Age = 88, MobileNo = "7686868", City = "Hyderabad", Post = "SE", Salary = 344777 },
                new Employee() { EID = 104, Name = "Prakash", Age = 39, MobileNo = "34686868", City = "Nagpur", Post = "Clerk", Salary = 56777 },
                new Employee() { EID = 105, Name = "Chadnan", Age = 9, MobileNo = "45686868", City = "Chennai", Post = "PO", Salary = 45777 }
                };
            return listemp;
        }


        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}