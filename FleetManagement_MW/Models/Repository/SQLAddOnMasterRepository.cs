using FleetManagement_MW.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement_MW.Models.Repository
{
    public class SQLAddOnMasterRepository : IAddOnMasterInterface
    {
        private readonly AppDbContext context;

        public SQLAddOnMasterRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<AddOnMaster>?> GetAddOnItems(long addOnId)
        {
            if (context.AddOnMasters == null)
            {
                return null;
            }
            var addon = await context.AddOnMasters.FindAsync(addOnId);

            if (addon == null)
            {
                return null;
            }

            return addon;
        }

        public async Task<ActionResult<IEnumerable<AddOnMaster>?>> GetAllAddOnItems()
        {
            if (context.AddOnMasters == null)
            {
                return null;
            }
            return await context.AddOnMasters.ToListAsync();

        }

    }
}
