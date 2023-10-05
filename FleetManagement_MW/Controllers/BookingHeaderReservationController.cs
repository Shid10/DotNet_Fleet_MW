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
    public class BookingHeaderReservationController : ControllerBase
    {
        private readonly IBookingHeaderReservationInterface _bookingHeaderReservationRepository;

        public BookingHeaderReservationController(IBookingHeaderReservationInterface bookingHeaderReservationRepository)
        {
            _bookingHeaderReservationRepository = bookingHeaderReservationRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingHeaderReservation>> GetBookingHeaderReservation(long id)
        {
            var bookingHeaderReservation = await _bookingHeaderReservationRepository.GetBookingHeaderReservation(id);
            if (bookingHeaderReservation == null)
            {
                return NotFound();
            }
            return bookingHeaderReservation;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingHeaderReservation>>> GetAllBookingHeaderReservations()
        {
            var bookingHeaderReservations = await _bookingHeaderReservationRepository.GetAllBookingHeaderReservations();
            return bookingHeaderReservations;
        }

        [HttpPost]
        public IActionResult AddBookingHeaderReservation(BookingHeaderReservation bookingHeaderReservation)
        {
            if (ModelState.IsValid)
            {
                _bookingHeaderReservationRepository.AddBookingHeaderReservation(bookingHeaderReservation);
                _bookingHeaderReservationRepository.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBookingHeaderReservation(long id, BookingHeaderReservation bookingHeaderReservation)
        {
            if (id != bookingHeaderReservation.bookingId)
            {
                return BadRequest();
            }

            _bookingHeaderReservationRepository.UpdateBookingHeaderReservation(bookingHeaderReservation);
            _bookingHeaderReservationRepository.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookingHeaderReservation(long id)
        {
            var bookingHeaderReservation = _bookingHeaderReservationRepository.GetBookingHeaderReservation(id);
            if (bookingHeaderReservation == null)
            {
                return NotFound();
            }

            _bookingHeaderReservationRepository.RemoveBookingHeaderReservation(id);
            _bookingHeaderReservationRepository.SaveChanges();
            return Ok();
        }
    }
}
