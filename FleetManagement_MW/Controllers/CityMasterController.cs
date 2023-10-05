using FleetManagement_MW.Models;
using FleetManagement_MW.Models.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement_MW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]

    public class CityController : Controller

    {
        private readonly ICityMasterInterface _repository;
        public CityController(ICityMasterInterface repository)
        {
            _repository = repository;

        }


        // GET: CityController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityMaster>?>> GetCity()
        {
            if (await _repository.GetAllCity() == null)
            {
                return NotFound();
            }

            return await _repository.GetAllCity();
        }




        // GET: CityController/Details/5

        [HttpGet("{id}")]
        public async Task<ActionResult<CityMaster>> GetById_ActionResultOfT(long id)
        {
            var city = await _repository.GetCity(id);
            return city == null ? NotFound() : city;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(long id, CityMaster city)
        {
            if (id != city.cityId)
            {
                return BadRequest();
            }
            try
            {
                await _repository.Update(id, city);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_repository.GetCity(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CityMaster>> PostCity(CityMaster city)
        {
            await _repository.Add(city);
            return CreatedAtAction("PostEmployee", new { id = city.cityId }, city);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(long id)
        {
            if (_repository.GetAllCity() == null)
            {
                return NotFound();
            }
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
