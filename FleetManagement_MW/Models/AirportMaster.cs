using System.ComponentModel.DataAnnotations;

namespace FleetManagement_MW.Models
{
    public class AirportMaster
    {
        [Key] 
        public long airportId { get; set; }
        public string airportName { get; set;}
        public long cityId { get; set; }
        public long stateId { get; set; }
        public long hubId { get; set; } 
        public long airportCode { get; set; }
        public string address { get; set; }
        public string openingTime { get; set; }
        public string closingTime { get; set; }
        public CityMaster city { get; set; }
        public StateMaster state { get; set; }
        public HubMaster hub { get; set; }
    }
}
