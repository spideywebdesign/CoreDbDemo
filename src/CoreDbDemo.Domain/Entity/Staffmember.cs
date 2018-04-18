using System.Collections.Generic;

namespace CoreDbDemo.Model.Entity
{
    public class StaffMember : EntityBase
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int RetailerId { get; set; }

        public virtual Retailer Retailer { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
