using FleetManagement_MW.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement_MW.Models.Repository
{
    public class SQLCityMasterRepository : ICityMasterInterface
    {

        private readonly AppDbContext context;

        public SQLCityMasterRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<CityMaster>> Add(CityMaster citymaster)
        {
            context.CityMasters.Add(citymaster);
            await context.SaveChangesAsync();
            return citymaster;
        }

        public async Task<CityMaster> Delete(long cityId)
        {
            CityMaster citymaster = context.CityMasters.Find(cityId);
            if (citymaster != null)
            {
                context.CityMasters.Remove(citymaster);
                await context.SaveChangesAsync();
            }
            return citymaster;

        }

        public async Task<ActionResult<IEnumerable<CityMaster>>> GetAllCity()
        {
            if (context.CityMasters == null)
            {
                return null;
            }
            return await context.CityMasters.ToListAsync();
        }

        public async Task<ActionResult<CityMaster>?> GetCity(long cityId)
        {
            if (context.CityMasters == null)
            {
                return null;
            }
            var citymaster = await context.CityMasters.FindAsync(cityId);

            if (citymaster == null)
            {
                return null;
            }
            return citymaster;
        }

        public async Task<CityMaster?> Update(long id, CityMaster citymaster)
        {
            if (id != citymaster.cityId)
            {
                return null;
            }
            context.Entry(citymaster).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return null;
        }
        private bool CityExists(long id)
        {
            return (context.CityMasters?.Any(c => c.cityId == id)).GetValueOrDefault();
        }


    }
}
