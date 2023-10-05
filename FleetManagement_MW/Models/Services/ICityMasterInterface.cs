using Microsoft.AspNetCore.Mvc;

namespace FleetManagement_MW.Models.Services
{
    public interface ICityMasterInterface
    {

        Task<ActionResult<CityMaster>?> GetCity(long cityId);

        Task<ActionResult<IEnumerable<CityMaster>>> GetAllCity();

        Task<ActionResult<CityMaster>> Add(CityMaster cityMaster);

        Task<CityMaster> Update(long cityId, CityMaster cityMaster);

        Task<CityMaster> Delete(long cityId);
    }
}
