using FleetManagement_MW.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement_MW.Models.Repository
{
    public class SQLBookingHeaderReservationRepository : IBookingHeaderReservationInterface
    {
        private readonly AppDbContext _context;

        public SQLBookingHeaderReservationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<BookingHeaderReservation>> GetBookingHeaderReservation(long bookingId)
        {
            return await _context.BookingHeaderReservations
                .Include(bhr => bhr.cust)
                .Include(bhr => bhr.carType)
                .FirstOrDefaultAsync(bhr => bhr.bookingId == bookingId);
        }

        public async Task<ActionResult<IEnumerable<BookingHeaderReservation>>> GetAllBookingHeaderReservations()
        {
            var bookingHeaderReservations = await _context.BookingHeaderReservations
                .Include(bhr => bhr.cust)
                .Include(bhr => bhr.carType)
                .ToListAsync();

            return bookingHeaderReservations;
        }

        public async Task<ActionResult<IEnumerable<BookingHeaderReservation>>> GetBookingHeaderReservationsByCustomerId(long customerId)
        {
            return await _context.BookingHeaderReservations
                .Where(bhr => bhr.customerId == customerId)
                .Include(bhr => bhr.cust)
                .Include(bhr => bhr.carType)
                .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<BookingHeaderReservation>>> GetBookingHeaderReservationsByCarTypeId(long carTypeId)
        {
            return await _context.BookingHeaderReservations
                .Where(bhr => bhr.carTypeId == carTypeId)
                .Include(bhr => bhr.cust)
                .Include(bhr => bhr.carType)
                .ToListAsync();
        }

        public void AddBookingHeaderReservation(BookingHeaderReservation bookingHeaderReservation)
        {
            _context.BookingHeaderReservations.Add(bookingHeaderReservation);
        }

        public void UpdateBookingHeaderReservation(BookingHeaderReservation bookingHeaderReservation)
        {
            _context.BookingHeaderReservations.Update(bookingHeaderReservation);
        }

        public void RemoveBookingHeaderReservation(long bookingId)
        {
            var bookingHeaderReservation = _context.BookingHeaderReservations.Find(bookingId);
            if (bookingHeaderReservation != null)
            {
                _context.BookingHeaderReservations.Remove(bookingHeaderReservation);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
