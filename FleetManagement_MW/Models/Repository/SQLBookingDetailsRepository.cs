using FleetManagement_MW.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement_MW.Models.Repository
{
    public class SQLBookingDetailsRepository : IBookingDetailsInterface
    {
        private readonly AppDbContext _context;

        public SQLBookingDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public BookingDetails GetBookingDetailsById(long bookingDetailsId)
        {
            return _context.BookingDetails
                .Include(bd => bd.booking)
                .FirstOrDefault(bd => bd.bookingDetailsId == bookingDetailsId);
        }

        public IEnumerable<BookingDetails> GetAllBookingDetails()
        {
            return _context.BookingDetails
                .Include(bd => bd.booking)
                .ToList();
        }

        public void AddBookingDetails(BookingDetails bookingDetails)
        {
            _context.BookingDetails.Add(bookingDetails);
        }

        public void UpdateBookingDetails(BookingDetails bookingDetails)
        {
            _context.BookingDetails.Update(bookingDetails);
        }

        public void RemoveBookingDetails(long bookingDetailsId)
        {
            var bookingDetails = _context.BookingDetails.Find(bookingDetailsId);
            if (bookingDetails != null)
            {
                _context.BookingDetails.Remove(bookingDetails);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
