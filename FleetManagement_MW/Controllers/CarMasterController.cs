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
    public class CarMasterController : ControllerBase
    {
        private readonly ICarMasterRepository _carRepository;

        public CarMasterController(ICarMasterRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _carRepository.GetAllCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetCar(long id)
        {
            var car = _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public IActionResult CreateCar(CarMaster car)
        {
            if (ModelState.IsValid)
            {
                _carRepository.AddCar(car);
                _carRepository.SaveChanges();
                return CreatedAtAction(nameof(GetCar), new { id = car.carId }, car);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(long id, CarMaster car)
        {
            if (id != car.carId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _carRepository.UpdateCar(car);
                _carRepository.SaveChanges();
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(long id)
        {
            var car = _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            _carRepository.RemoveCar(id);
            _carRepository.SaveChanges();
            return NoContent();
        }
    }
}
