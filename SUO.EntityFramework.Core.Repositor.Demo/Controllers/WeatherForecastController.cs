using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SUO.EntityFramework.Core.Repositor.Demo.Model;
using SUO.EntityFramework.Core.Repository;

namespace SUO.EntityFramework.Core.Repositor.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IBaseRepository<UserInfo, Guid> _userRepository;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBaseRepository<UserInfo, Guid> _userRepository)
        {
            _logger = logger;
            this._userRepository = _userRepository;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            Guid id = new Guid();

            UserInfo u= _userRepository.Add(new UserInfo()
                {Id = id,UserName = "张三", UserInfoDetailed = new UserInfoDetailed() {Id = id, Age = 11}});
            _userRepository.Commit();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
