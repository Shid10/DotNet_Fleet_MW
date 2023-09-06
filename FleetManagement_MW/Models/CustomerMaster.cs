using System.ComponentModel.DataAnnotations;

namespace FleetManagement_MW.Models
{
    public class CustomerMaster
    {
        [Key]
        public long customerId { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? address1 { get; set; }
        public string? address2 { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
       // public CityMaster city { get; set; }
      //  public long cityId { get; set; }
       // public long stateId { get; set; }
       // public StateMaster state { get; set; }
        public string? pin { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
        public string? creditCardType { get; set; }
        public string? drivingLicence { get; set; }
        public string? dlIssuedBy { get; set; }
        public DateTime dlValidThrough { get; set; }
        public string? passportNumber { get; set; }
        public string? passportIssuedBy { get; set; }
        public DateTime passportValidUpto { get; set; }
        public DateTime dob { get; set; }
    }
}
