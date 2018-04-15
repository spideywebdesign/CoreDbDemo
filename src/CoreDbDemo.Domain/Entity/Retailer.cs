using System.Collections.Generic;

namespace CoreDbDemo.Model.Entity
{
    public class Retailer : EntityBase
    {
        public string RetailerCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }

        public virtual ICollection<StaffMember> StaffMembers { get; set; }
    }
}
