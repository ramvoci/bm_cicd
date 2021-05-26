using BenMedica.Api.Processor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace BenMedica.Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class DrugController : ControllerBase {
        private static readonly string[] Description = new[]
        {
            "RF1234", "RF1235", "RF1236", "RF1237", "RF1238", "RF1239", "RF1240", "RF1241", "RF1242", "RF1243"
        };

        private readonly ILogger<DrugController> _logger;

        public DrugController(ILogger<DrugController> logger) {
            _logger = logger;
        }

        /// <summary>
        ///  fetch the Infomation for main and it's alterntives drug
        /// </summary>
        /// <param name="dispenseCodes"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post([FromBody] DispenseCodes dispenseCodes) {

            try {
                RequestProcessor requestProcessor = new RequestProcessor();
                if (dispenseCodes.PayerId == null) {
                    return Ok(requestProcessor.CheckPayerId(dispenseCodes));
                };
                if (dispenseCodes.Source == null) {
                    return Ok(requestProcessor.CheckRequestId(dispenseCodes));
                } else {
                    return Ok(requestProcessor.ProcessRequest(dispenseCodes));
                }




                /* switch (dispenseCodes.Request.DispensibleDrug.Code) {

                     case "72931001202":
                         if(dispenseCodes.Request.)

                         var pipeSeparatedAlternatives = string.Join("|", dispenseCodes.Alternatives?.Select(x => x.DispensibleDrug.Code));
                         Random random = new Random();

                         switch (pipeSeparatedAlternatives) {
                             case "00071015545|00071015530|00071015515":
                                 string[] codes = pipeSeparatedAlternatives.Split("|");
                                 int index = random.Next(codes.Count());

                                 foreach (var alterntive in codes) {
                                     if (alterntive == codes[index] && requestedDrugxCodeFound) {
                                         var alternativeDrug = dispenseCodes.Alternatives.Where(x => x.DispensibleDrug.Code == alterntive).FirstOrDefault();
                                         alternativeDrug.DaysSupply = 21;
                                         alternativeDrug.Quantity = "32";
                                         alternativeDrug.ErrorOccurred = true;
                                         alternativeDrug.ErrorCode = "E00A";
                                         alternativeDrug.ErrorDescription = "Unknown DispensibleDrug.Code";
                                     } else {
                                         var alternativeDrug = dispenseCodes.Alternatives.Where(x => x.DispensibleDrug.Code == alterntive).FirstOrDefault();
                                         alternativeDrug.DaysSupply = 21;
                                         alternativeDrug.Quantity = "34.5";
                                         alternativeDrug.ErrorOccurred = false;
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
                */

                var response = JsonConvert.SerializeObject(dispenseCodes, Formatting.Indented, new JsonSerializerSettings {
                    NullValueHandling = NullValueHandling.Ignore
                });

                return Ok(response);
            } catch (Exception) {

                return this.StatusCode(StatusCodes.Status400BadRequest, "unable to  process the request");
            }
        }

      



    }
    }
