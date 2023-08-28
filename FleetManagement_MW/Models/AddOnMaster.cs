using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement_MW.Models
{
    public class AddOnMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long addOnId { get; set; }

        public string addOnName { get; set; }

        public double addOnRate { get; set; }

        public DateTime rateValidity { get; set; }

        public CarMaster car { get; set; }
        public long carId { get; set; }
       
    }
}
