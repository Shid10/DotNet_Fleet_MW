using System.ComponentModel.DataAnnotations;

namespace FleetManagement_MW.Models
{
    public class StateMaster
    {
        [Key]
        public long stateId { get; set; }
        public string stateName { get; set; }
    }
}
