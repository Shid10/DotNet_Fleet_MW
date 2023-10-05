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
    public class CarTypeMasterController : ControllerBase
    {
        private readonly ICarTypeMasterRepository _carTypeRepository;

        public CarTypeMasterController(ICarTypeMasterRepository carTypeRepository)
        {
            _carTypeRepository = carTypeRepository;
        }

        [HttpGet]
        public IActionResult GetCarTypes()
        {
            var carTypes = _carTypeRepository.GetAllCarTypes();
            return Ok(carTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarType(long id)
        {
            var carType = _carTypeRepository.GetCarTypeById(id);
            if (carType == null)
            {
                return NotFound();
            }
            return Ok(carType);
        }

        [HttpGet("ByHub/{hubId}")]
        public IActionResult GetCarTypesByHub(long hubId)
        {
            var carTypes = _carTypeRepository.GetCarTypesByHubId(hubId);
            return Ok(carTypes);
        }

        [HttpPost]
        public IActionResult CreateCarType(CarTypeMaster carType)
        {
            if (ModelState.IsValid)
            {
                _carTypeRepository.AddCarType(carType);
                _carTypeRepository.SaveChanges();
                return CreatedAtAction(nameof(GetCarType), new { id = carType.carTypeId }, carType);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCarType(long id, CarTypeMaster carType)
        {
            if (id != carType.carTypeId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _carTypeRepository.UpdateCarType(carType);
                _carTypeRepository.SaveChanges();
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCarType(long id)
        {
            var carType = _carTypeRepository.GetCarTypeById(id);
            if (carType == null)
            {
                return NotFound();
            }

            _carTypeRepository.RemoveCarType(id);
            _carTypeRepository.SaveChanges();
            return NoContent();
        }
    }
}
