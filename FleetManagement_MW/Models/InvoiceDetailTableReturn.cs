using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement_MW.Models
{
    public class InvoiceDetailTableReturn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long invoiceDetailId { get; set; }
        public long invoiceId { get; set; }
        public InvoiceHeaderTableHandover invoice { get; set; }
        public long addOnId { get; set; }
        public AddOnMaster addOn { get; set; }

        public double addOnAmt { get; set; }
    }
}
