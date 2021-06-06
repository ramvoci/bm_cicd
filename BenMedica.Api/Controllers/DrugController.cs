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

        private readonly ILogger<DrugController> _logger;

        public DrugController(ILogger<DrugController> logger) {
            _logger = logger;
        }

        /// <summary>
        ///  fetch the information for main and its alternatives drug
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
            } catch (Exception) {

                return this.StatusCode(StatusCodes.Status400BadRequest, "unable to  process the request");
            }
        }

    }
}
