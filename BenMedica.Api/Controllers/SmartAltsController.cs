using BenMedica.Api.Processor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;


namespace BenMedica.Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class SmartAltsController : ControllerBase {

        private readonly ILogger<SmartAltsController> _logger;
        private readonly SmartAltsResponse _smartAltsResponse;
        public SmartAltsController(ILogger<SmartAltsController> logger, SmartAltsResponse smartAltsResponse) {
            _logger = logger;
            _smartAltsResponse = smartAltsResponse;
        }

        /// <summary>
        /// Request SmartAlts DaysSupply, Quantity, QuantityUnitOfMeasure information for a SourceProduct and a list of AlternativeProducts.
        /// </summary>
        /// <param name="smartAltsRequest">Supplies the SmartAltsRequest</param>
        /// <returns> SmartAltsResponse</returns>
        /// <response code = "200">Returns the SmartAltsResponse</response>
        /// <response code = "400">Returns the HttpClientErrorResponse</response>
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(SmartAltsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpClientErrorResponse), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] SmartAltsRequest smartAltsRequest) {

            try {
                RequestProcessor requestProcessor = new RequestProcessor(_smartAltsResponse);
                bool isSourceProductRequestCodeFound = !requestProcessor.IsSourceProductRequestCodeFoundInDatabase(smartAltsRequest);

                if ((ModelState.Keys.Contains("PayerId") || ModelState.Keys.Contains("SourceProductRequest")) || (isSourceProductRequestCodeFound))
                    return BadRequest(requestProcessor.GenerateErrorResponse(ModelState, smartAltsRequest, isSourceProductRequestCodeFound));

                //if (!requestProcessor.IsSourceProductRequestCodeFoundInDatabase(smartAltsRequest))
                //    return BadRequest(requestProcessor.GenerateErrorResponse(ModelState, smartAltsRequest));
                
                return Ok(requestProcessor.ProcessRequest(smartAltsRequest));

            } catch (Exception exception) {
                return BadRequest(exception);

            }
        }

    }
}
