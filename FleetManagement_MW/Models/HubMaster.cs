using System.ComponentModel.DataAnnotations;

namespace FleetManagement_MW.Models
{
    public class HubMaster
    {
        [Key]
        public long hubId { get; set; }
        public string hubName { get; set; }
public string hubAddress { get; set; }
        public long cityId { get; set; }
        public long stateId { get; set; }
        public string hubPhoneNo { get; set; }
        public string openingHours { get; set; }
        public StateMaster state { get; set; }
        public CityMaster city { get; set; }    
    }
}
