using System.Collections.Generic;

namespace CoreDbDemo.Model.Entity
{
    public class RetailerDbo : EntityBase
    {
        public string RetailerCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public int BrandId { get; set; }
        public int AreaManagerId { get; set; }

        public virtual AreaManagerDbo AreaManager { get; set; }
        public virtual BrandDbo Brand { get; set; }
        public virtual ICollection<StaffMemberDbo> StaffMembers { get; set; }
    }
}