using Microsoft.AspNetCore.Mvc;

namespace FleetManagement_MW.Models.Services
{
    public interface IAirportMasterInterface
    {
        Task<ActionResult<AirportMaster>> GetAirport(long airportId);
        Task<ActionResult<IEnumerable<AirportMaster>>> GetAllAirports();
        Task<ActionResult<AirportMaster>> GetAirportByAirportName(string airportName);
        Task<ActionResult<AirportMaster>> showAirportList(long airportcode);

        

    }
}
