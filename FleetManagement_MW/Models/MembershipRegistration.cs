using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement_MW.Models
{
    public class MembershipRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long memRegId { get; set; }
        public long customerId { get; set; }
        public CustomerMaster cust { get; set; }
        public long carTypeId { get; set; }
        public CarTypeMaster carType { get; set; }

        public string password { get; set; }
    }
}
