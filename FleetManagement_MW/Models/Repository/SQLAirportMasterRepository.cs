using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetManagement_MW.Models;
using FleetManagement_MW.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement_MW.Models.Repository
{
    public class SQLAirportMasterRepository : IAirportMasterInterface
    {
        private readonly AppDbContext _context;
        public SQLAirportMasterRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<ActionResult<AirportMaster>> GetAirport(long airportId)
        {
            if (_context.AirportMasters == null)
            {
                return null;
            }
            var airport = await _context.AirportMasters.FindAsync(airportId);

            if (airport == null)
            {
                return null;
            }

            return airport;

        }

        public async Task<ActionResult<AirportMaster>> GetAirportByAirportName(string airportName)
        {
            var airport = await _context.AirportMasters
                .FirstOrDefaultAsync(a => a.airportName == airportName);

            if (airport == null)
            {
                return null; // Return appropriate status if not found
            }

            return airport;
        }


        public async Task<ActionResult<IEnumerable<AirportMaster>>> GetAllAirports()
        {
            if (_context.AirportMasters == null)
            {
                return null;
            }
            return await _context.AirportMasters.ToListAsync();

        }

        public Task<ActionResult<AirportMaster>> showAirportList(long airportcode)
        {
            throw new NotImplementedException();
        }
    }
}
