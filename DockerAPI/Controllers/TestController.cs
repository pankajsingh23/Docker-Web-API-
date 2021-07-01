using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DockerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private static readonly string[] Cities = new[]
        {
            "Delhi", "Mumbai", "Kolkata", "Chennai", "Bengaluru"
        };

        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<City> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new City
            {
                Name = Cities[rng.Next(Cities.Length)]
            })
            .ToArray();
        }
    }
}

