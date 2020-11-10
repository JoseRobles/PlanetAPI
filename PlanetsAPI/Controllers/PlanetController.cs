using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Infrastructure;

namespace PlanetsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IService _planetService;
        public PlanetController(IConfiguration configuration, IService service)
        {
            _configuration = configuration;
            _planetService = service;
            _planetService.SetUrls(_configuration["API_URLs:SecurityAPI"], _configuration["API_URLs:Planets_API"]);
            _planetService.SetCredentials(_configuration["Credentials:Username"], _configuration["Credentials:Password"]);
        }

        [HttpGet]
        public IEnumerable<Planet> Get()
        {
            var planets = new List<Planet>();
            return _planetService.GetData(); ;
        }


    }
}
