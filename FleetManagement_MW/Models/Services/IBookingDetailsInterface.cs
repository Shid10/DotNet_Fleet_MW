namespace FleetManagement_MW.Models.Services
{
    public interface IBookingDetailsInterface
    {
        BookingDetails GetBookingDetailsById(long bookingDetailsId);
        IEnumerable<BookingDetails> GetAllBookingDetails();
        void AddBookingDetails(BookingDetails bookingDetails);
        void UpdateBookingDetails(BookingDetails bookingDetails);
        void RemoveBookingDetails(long bookingDetailsId);
        void SaveChanges();

    }
}
