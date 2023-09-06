using System.ComponentModel.DataAnnotations;

namespace FleetManagement_MW.Models
{
    public class CityMaster
    {
        [Key] 
        public long cityId { get; set; }
        public string cityName { get; set; }
        // Other properties

        public long stateId { get; set; }
        public StateMaster state { get; set; }
    }
}
