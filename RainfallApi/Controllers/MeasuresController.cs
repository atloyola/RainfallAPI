using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RainfallApi.Domain.Entities;
using RainfallApi.Domain.Interfaces;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;

namespace RainfallApi.Controllers
{
    [ApiController]
    [Route("api/rainfall/measures")]
    public class MeasuresController : ControllerBase
    {
        private readonly IMeasureRepository _measureRepository;

        public MeasuresController(IMeasureRepository measureRepository)
        {
            _measureRepository = measureRepository;
        }

        /// <summary>
        /// List the available measures by station reference
        /// </summary>        
        /// <param name="stationReference"></param>
        /// <returns> Return only those measures which are available from the station with the station reference identifier</returns>        
        /// <response code="200">List of Available Measures Successfully Retrieved</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No measures found for the specified station reference identifier.</response>
        /// <response code="500">Internal server error</response>       
        [HttpGet]        
        [ProducesResponseType(type: typeof(Measure), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]                
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<Measure>>> GetAllMeasures(string stationReference = "3680")
        {
            if (stationReference == "")
                return BadRequest("Invalid Request");

            try
            {
                var allMeasures = await _measureRepository.GetMeasuresByStationReferenceAsync(stationReference);

                if (allMeasures == null || !allMeasures.Any())
                {
                    return NotFound("No measures found for the specified station reference identifier.");
                }

                return Ok(allMeasures);

            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
