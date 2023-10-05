using FleetManagement_MW.Models;
using FleetManagement_MW.Models.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement_MW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class AddOnController : ControllerBase
    {

        private readonly IAddOnMasterInterface _repository;

        public AddOnController(IAddOnMasterInterface repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddOnMaster>?>> GetAddOnItems()
        {
            if (await _repository.GetAllAddOnItems() == null)
            {
                return NotFound();
            }

            return await _repository.GetAllAddOnItems();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddOnMaster>> GetById_ActionResultOfTl(long id)
        {
            var addon = await _repository.GetAddOnItems(id);
            return addon == null ? NotFound() : addon;
        }



    }
}
