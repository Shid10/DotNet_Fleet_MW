using FleetManagement_MW.Models;
using FleetManagement_MW.Models.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement_MW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class AirportMasterController : ControllerBase
    {
        private readonly IAirportMasterInterface _Repository;
        public AirportMasterController(IAirportMasterInterface repository)
        {
            _Repository = repository;
        }
        [HttpGet("airportId:long")]
        public async Task<ActionResult<AirportMaster>> GetAirport(long airportId)
        {
            var airport = await _Repository.GetAirport(airportId);

            if (airport == null)
            {
                return NotFound();
            }

            return airport.Value;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirportMaster>>> GetAllAirports()
        {
            var airports = await _Repository.GetAllAirports();
            return airports.Value.ToList();
        }

        [HttpGet("airportcode:long")]
        public async Task<ActionResult<AirportMaster>> ShowAirportList(long airportcode)
        {
            var airport = await _Repository.showAirportList(airportcode);

            if (airport == null)
            {
                return NotFound();
            }

            return airport.Value;
        }

        [HttpGet("GetByAirportName/{airportName}")]
        public async Task<ActionResult<AirportMaster>> GetAirportByAirportName(string airportName)
        {
            return await _Repository.GetAirportByAirportName(airportName);
        }

    }
}
