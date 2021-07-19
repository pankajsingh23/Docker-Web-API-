using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace DockerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly ILogger<TestController> _logger;

        private static readonly string[] Cities = new[]
        {
            "Delhi", "Mumbai", "Kolkata", "Chennai", "Bengaluru"
        };

        public TestController(ILogger<TestController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<City> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new City
            {
                Name = Cities[rng.Next(Cities.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        //[Route("api/test/GetFile/{file:string}")]
        [Route("[Action]")]
        //public string GetFile([FromQuery] string file)
        public string GetFile(string file)
        {
            return System.IO.File.ReadAllText(file, Encoding.UTF8);
        }

        //[HttpGet]
        //[Route("[Action]")]
        //public string GetFile([FromQuery] FileComponent file)
        //{
        //    return System.IO.File.ReadAllText(System.IO.Path.Combine(file.Directory, file.FileNameWithExtension), Encoding.UTF8);
        //}

        [HttpGet]
        [Route("[Action]")]
        public string GetMountPath()
        {
            return _configuration["AppSettings:MountPath"];
        }

    }
}

