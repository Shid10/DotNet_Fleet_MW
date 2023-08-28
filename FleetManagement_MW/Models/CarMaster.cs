using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement_MW.Models
{
    public class CarMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long carId { get; set; }
        public long carTypeId { get; set; }
        public CarTypeMaster carType { get; set; }

        public double carFuelCapacity { get; set; }

      public long hubId { get; set; }
        public HubMaster hub{ get; set; }

        public bool isAvailable { get; set; }
        public DateTime maintenanceDueDate { get; set; }
        public double carCurrentFuelStatus { get; set; }
    }
}
