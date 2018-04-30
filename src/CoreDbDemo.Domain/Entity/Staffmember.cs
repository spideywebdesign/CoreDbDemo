using System.Collections.Generic;

namespace CoreDbDemo.Model.Entity
{
    public class StaffMemberDbo : EntityBase
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int RetailerId { get; set; }

        public virtual RetailerDbo Retailer { get; set; }
        public virtual ICollection<RequestDbo> Requests { get; set; }
    }
}