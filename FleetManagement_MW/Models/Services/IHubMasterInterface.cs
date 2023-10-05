using Microsoft.AspNetCore.Mvc;

namespace FleetManagement_MW.Models.Services
{
    public interface IHubMasterInterface
    {
        Task<ActionResult<HubMaster>?> GetHubByhubId(long hubId);
        Task<ActionResult<IEnumerable<HubMaster>>> GetAllHubs();
        Task<ActionResult<HubMaster>> Add(HubMaster hub);
        Task<ActionResult<IEnumerable<HubMaster>>> GetHubByCityId(long cityId);
    }
}
