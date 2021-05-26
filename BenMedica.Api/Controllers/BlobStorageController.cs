using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BenMedica.Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class BlobStorageController : ControllerBase {
        private readonly ILogger<BlobStorageController> _logger;
        private readonly IBlobService _blobService;

        public BlobStorageController(ILogger<BlobStorageController> logger, IBlobService blobService) {
            _logger = logger;
            _blobService = blobService;
        }

        /// <summary>
        /// Get the blob using filename
        /// </summary>
        /// <returns>get the blob content</returns>
        //[HttpGet("{filename}")]
        //public async Task<IActionResult> Get(string filename) {
        //    try {
        //        var response = await _blobService.GetBlobAsync(filename);
        //        return Ok(response.Content);

        //    } catch (Exception) {

        //        return this.StatusCode(StatusCodes.Status404NotFound, "File not found in the blob");
        //    }

        //}
    }
}
