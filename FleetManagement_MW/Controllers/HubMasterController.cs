using FleetManagement_MW.Models.Services;
using FleetManagement_MW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace FleetManagement_MW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class HubMasterController : ControllerBase
    {
        private readonly IHubMasterInterface _repository;
        public HubMasterController(IHubMasterInterface repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HubMaster>>> GetAllHubs()
        {
            if (await _repository.GetAllHubs() == null)
            {
                return NotFound();
            }
            return await _repository.GetAllHubs();
        }

        [HttpGet("hubId:long")]
        public async Task<ActionResult<HubMaster>> GetHubByhubId(long hubId)
        {
            var hub = await _repository.GetHubByhubId(hubId);
            return hub == null ? NotFound() : hub;
        }

        [HttpGet("cityId:long")]
        public async Task<ActionResult<IEnumerable<HubMaster>>> GetHubBycityId(long cityId)
        {
            var hub = await _repository.GetHubByCityId(cityId);
            return hub == null ? NotFound() : hub;
        }

        [HttpPost]
        public async Task<ActionResult<HubMaster>> AddHub(HubMaster hub)
        {
            await _repository.Add(hub);
            return CreatedAtAction("AddHub", new { id = hub.hubId }, hub);
        }
    }
}
