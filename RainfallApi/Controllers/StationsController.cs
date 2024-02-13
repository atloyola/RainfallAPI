using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RainfallApi.Domain.Entities;
using RainfallApi.Domain.Interfaces;
using System.Net.Mime;

namespace RainfallApi.Controllers
{
    [ApiController]
    [Route("api/rainfall/stations")]
    public class StationsController : ControllerBase
    {
        private readonly IStationRepository _stationRepository; 

        public StationsController(IStationRepository stationRepository) 
        {
            _stationRepository = stationRepository;
        }

        /// <summary>
        /// Get list of all stations that offer a rainfall measurement
        /// </summary>        
        /// <returns> Returns a list of all stations that offer a rainfall measurement</returns>        
        /// <response code="200">A list of stations successfully retrieved</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No stations found that offer a rainfall measurement.</response>
        /// <response code="500">Internal server error</response>               
        [HttpGet]
        [ProducesResponseType(type: typeof(Station), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<Station>>> GetRainfallStations()
        {
            try
            {
                var stations = await _stationRepository.GetStationsAsync();
            
                if (stations == null || !stations.Any())
                {
                    return NotFound("No rainfall stations found.");
                }

                return Ok(stations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
