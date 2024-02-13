using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RainfallApi.Domain.Entities;
using RainfallApi.Domain.Interfaces;
using System.Net.Mime;

namespace RainfallApi.Controllers
{
    [ApiController]
    [Route("api/rainfall/readings")]
    public class ReadingsController : ControllerBase
    {
        private readonly IReadingRepository _readingRepository;

        public ReadingsController(IReadingRepository readingRepository) 
        {
            _readingRepository = readingRepository;
        }

        /// <summary>
        /// Get rainfall readings by station reference identifier
        /// </summary>
        /// <remarks>
        /// Retrieve the latest rainfall readings for the specified station Id
        /// </remarks>
        /// <param name="stationReference"></param>
        /// <returns> Return only those measures which are available from the station with the station reference identifier</returns>        
        /// <response code="200">A list of rainfall readings successfully retrieved for the specified station Id</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No readings found for the specified station reference identifier.</response>
        /// <response code="500">Internal server error</response>       
        [HttpGet]
        [ProducesResponseType(type: typeof(Reading), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]        
        public async Task<ActionResult<IEnumerable<Reading>>> GetReadingsByStationReference(string stationReference = "3680")
        {
            if (stationReference == "")
                return BadRequest("Invalid Request");

            try 
            { 
                var readings = await _readingRepository.GetReadingsByStationReferenceAsync(stationReference, 10);

                if (readings == null || !readings.Any())
                {
                    return NotFound("No rainfall readings found for station reference id.");
                }

                return Ok(readings);

            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
