using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenMedica.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrugController : ControllerBase
    {
        private static readonly string[] Description = new[]
        {
            "RF1234", "RF1235", "RF1236", "RF1237", "RF1238", "RF1239", "RF1240", "RF1241", "RF1242", "RF1243"
        };

        private readonly ILogger<DrugController> _logger;

        public DrugController(ILogger<DrugController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get drug codes
        /// </summary>
        /// <returns>Drug values</returns>
        [HttpGet]
        public IEnumerable<Drug> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Drug
            {
                Date = DateTime.Now.AddDays(index),
                Codes="RF2343",
                Description = Description[rng.Next(Description.Length)]
            })
            .ToArray();
        }
    }
}
