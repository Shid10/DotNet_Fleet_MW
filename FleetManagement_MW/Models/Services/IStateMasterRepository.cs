using Microsoft.AspNetCore.Mvc;

namespace FleetManagement_MW.Models.Services
{
    public interface IStateMasterRepository
    {
        StateMaster GetStateById(long stateId);
        IEnumerable<StateMaster> GetAllStates();
    }
}
