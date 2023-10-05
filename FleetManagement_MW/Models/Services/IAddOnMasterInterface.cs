using Microsoft.AspNetCore.Mvc;

namespace FleetManagement_MW.Models.Services
{
    public interface IAddOnMasterInterface
    {

        Task<ActionResult<AddOnMaster>?> GetAddOnItems(long addOnId);

        Task<ActionResult<IEnumerable<AddOnMaster>>> GetAllAddOnItems();

    }
}
