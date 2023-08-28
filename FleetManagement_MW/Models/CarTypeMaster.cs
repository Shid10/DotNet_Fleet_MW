using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement_MW.Models
{
    public class CarTypeMaster
    {
        [Key]
        public long carTypeId { get; set; }

        public string carTypeName { get; set; }
        public double dailyRate { get; set; }

   public long hubId { get; set; }  
        public HubMaster hub { get; set; }

        public double weeklyRate { get; set; }
        public double monthlyRate { get; set; }
        public string imagePath { get; set; }
    }
}
