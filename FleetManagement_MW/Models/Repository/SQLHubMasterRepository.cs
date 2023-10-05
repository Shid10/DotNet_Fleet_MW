using FleetManagement_MW.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement_MW.Models.Repository
{
    public class SQLHubMasterRepository : IHubMasterInterface
    {
        private readonly AppDbContext context;
        public SQLHubMasterRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<HubMaster>> Add(HubMaster hub)
        {
            context.HubMasters.Add(hub);
            await context.SaveChangesAsync();
            return hub;
        }

        public async Task<ActionResult<IEnumerable<HubMaster>>> GetAllHubs()
        {
            if (context.HubMasters == null)
            {
                return null;
            }
            return await context.HubMasters.ToListAsync();
        }



        public async Task<ActionResult<IEnumerable<HubMaster>>> GetHubByCityId(long cityId)
        {
            var city = await context.CityMasters.FindAsync(cityId);
            if (city == null)
            {
                return null; // Return a 404 response if the city is not found.
            }

            var hubs = await context.HubMasters
                .Where(h => h.cityId == cityId)
                .ToListAsync();

            if (!hubs.Any())
            {
                return null; // Return a 204 response if no hubs are found for the city.
            }

            return hubs; // Return the list of hubs (can be empty or contain one or more items).
        }


        public async Task<ActionResult<HubMaster>?> GetHubByhubId(long hubId)
        {
            if (context.HubMasters == null)
            {
                return null;
            }
            var hub = await context.HubMasters.FindAsync(hubId);
            if (hub == null)
            {
                return null;
            }
            return hub;
        }
    }
}
