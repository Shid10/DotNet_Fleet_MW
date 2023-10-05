using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FleetManagement_MW.Models;
using FleetManagement_MW.Models.Services;
using Microsoft.AspNetCore.Cors;

namespace FleetManagement_MW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class StateMasterController : ControllerBase
    {
        private readonly IStateMasterRepository _stateRepository;

        public StateMasterController(IStateMasterRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        [HttpGet]
        public IActionResult GetStates()
        {
            var states = _stateRepository.GetAllStates();
            return Ok(states);
        }

        [HttpGet("{id}")]
        public IActionResult GetState(long id)
        {
            var state = _stateRepository.GetStateById(id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state);
        }
    }
}
