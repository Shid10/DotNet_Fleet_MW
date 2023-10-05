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
    public class BookingDetailsController : ControllerBase
    {
        private readonly IBookingDetailsInterface _bookingDetailsRepository;

        public BookingDetailsController(IBookingDetailsInterface bookingDetailsRepository)
        {
            _bookingDetailsRepository = bookingDetailsRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<BookingDetails> GetBookingDetailsById(long id)
        {
            var bookingDetails = _bookingDetailsRepository.GetBookingDetailsById(id);
            if (bookingDetails == null)
            {
                return NotFound();
            }
            return bookingDetails;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookingDetails>> GetAllBookingDetails()
        {
            var bookingDetailsList = _bookingDetailsRepository.GetAllBookingDetails().ToList();
            return bookingDetailsList;
        }

        [HttpPost]
        public IActionResult AddBookingDetails(BookingDetails bookingDetails)
        {
            if (ModelState.IsValid)
            {
                _bookingDetailsRepository.AddBookingDetails(bookingDetails);
                _bookingDetailsRepository.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBookingDetails(long id, BookingDetails bookingDetails)
        {
            if (id != bookingDetails.bookingDetailsId)
            {
                return BadRequest();
            }

            _bookingDetailsRepository.UpdateBookingDetails(bookingDetails);
            _bookingDetailsRepository.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookingDetails(long id)
        {
            var bookingDetails = _bookingDetailsRepository.GetBookingDetailsById(id);
            if (bookingDetails == null)
            {
                return NotFound();
            }

            _bookingDetailsRepository.RemoveBookingDetails(id);
            _bookingDetailsRepository.SaveChanges();
            return Ok();
        }
    }
}