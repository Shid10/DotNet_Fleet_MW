using Microsoft.AspNetCore.Mvc;

namespace FleetManagement_MW.Models.Services
{
    public interface IBookingHeaderReservationInterface
    {
        Task<ActionResult<BookingHeaderReservation>> GetBookingHeaderReservation(long bookingId);
        Task<ActionResult<IEnumerable<BookingHeaderReservation>>> GetAllBookingHeaderReservations();
        Task<ActionResult<IEnumerable<BookingHeaderReservation>>> GetBookingHeaderReservationsByCustomerId(long customerId);
        Task<ActionResult<IEnumerable<BookingHeaderReservation>>> GetBookingHeaderReservationsByCarTypeId(long carTypeId);
        void AddBookingHeaderReservation(BookingHeaderReservation bookingHeaderReservation);
        void UpdateBookingHeaderReservation(BookingHeaderReservation bookingHeaderReservation);
        void RemoveBookingHeaderReservation(long bookingId);
        void SaveChanges();
    }
}
