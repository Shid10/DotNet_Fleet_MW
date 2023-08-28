using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement_MW.Models
{
    public class InvoiceHeaderTableHandover
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long invoiceId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime invoiceDate { get; set; }
        public long bookingId { get; set; }
        public BookingHeaderReservation booking { get; set; }
        public long customerId { get; set; }
        public CustomerMaster cust { get; set; }

        [Column(TypeName = "Date")]
        public DateTime handoverDate { get; set; }
        public long carId { get; set; }
        public CarMaster car { get; set; }

        [Column(TypeName = "Date")]
        public DateTime returnDate { get; set; }

        public double rentalAmt { get; set; }
        public double totalAddonAmt { get; set; }
        public double totalAmt { get; set; }
        public string customerDetails { get; set; }
        public double invoiceRate { get; set; }
    }
}

