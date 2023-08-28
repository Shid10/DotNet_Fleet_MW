using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement_MW.Models
{
    public class BookingDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long bookingDetailsId { get; set; }
        public BookingHeaderReservation booking { get; set; }
        public long addOnId { get; set; }
        public AddOnMaster addoni { get; set; }
        public double addOnRate { get; set; }
        public AddOnMaster addonr { get; set; }


    }
}
