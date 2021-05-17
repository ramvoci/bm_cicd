using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace BenMedica.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                Codes = "RF2343",
                Description = Description[rng.Next(Description.Length)]
            })
            .ToArray();
        }
        /// <summary>
        /// get the response for request drugs and its alterntives drugs
        /// </summary>
        /// <param name="dispenseCodes"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post([FromBody] DispenseCodes dispenseCodes)
        {
            bool requestedDrugCodeFound = true;
            switch (dispenseCodes.Request.DispensibleDrug.Code) {

                case "00071015534":
                    if(requestedDrugCodeFound) {
                        dispenseCodes.Request.ErrorOccurred = false;
                    } else {
                        dispenseCodes.Request.ErrorOccurred = true;
                        dispenseCodes.Request.ErrorCode = "E00A";
                        dispenseCodes.Request.ErrorDescription = "Unknown DispensibleDrug.Code";

                    }

                    var pipeSeparatedAlternatives = string.Join("|", dispenseCodes.Alternatives?.Select(x => x.DispensibleDrug.Code));

                    switch (pipeSeparatedAlternatives) {
                        case "00071015545|00071015530|00071015515":
                           foreach(var alterntive in pipeSeparatedAlternatives.Split("|")) {

                                if(alterntive == "00071015545" || alterntive == "00071015515") {
                                   var alternativeDrug= dispenseCodes.Alternatives.Where(x => x.DispensibleDrug.Code == alterntive).FirstOrDefault();
                                    alternativeDrug.DaysSupply = 21;
                                    alternativeDrug.Quantity = "34.5";
                                    alternativeDrug.ErrorOccurred = false;
                                    
                                } else {
                                    var alternativeDrug = dispenseCodes.Alternatives.Where(x => x.DispensibleDrug.Code == alterntive).FirstOrDefault();
                                    alternativeDrug.DaysSupply = 21;
                                    alternativeDrug.Quantity = "32";
                                    alternativeDrug.ErrorOccurred = true;
                                    alternativeDrug.ErrorCode = "E00A";
                                    alternativeDrug.ErrorDescription = "Unknown DispensibleDrug.Code";
                                }
                            }

                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
           

            var response = JsonConvert.SerializeObject(dispenseCodes, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return Ok(response);
        }
    }
}
