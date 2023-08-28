using System.ComponentModel.DataAnnotations;

namespace FleetManagement_MW.Models
{
    public class BookingHeaderReservation
    {
        [Key]
        public long bookingId { get; set; }
        public DateTime bookingDate { get; set; }
        public long customerId { get; set; }
        public CustomerMaster cust { get; set; }
        public DateTime bookingStartDate { get; set; }
        public DateTime bookingEndDate { get; set; }
        public long carTypeId { get; set; }
        public CarTypeMaster carType { get; set; }
        public string custDetail { get; set; }
        public double dailyRate { get; set; }
        public double weeklyRate { get; set; }
        public double monthlyRate { get; set; }
    }
}
