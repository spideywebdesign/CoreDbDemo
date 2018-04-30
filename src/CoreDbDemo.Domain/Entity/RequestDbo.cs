using System;

namespace CoreDbDemo.Model.Entity
{
    public class RequestDbo : EntityBase
    {
        public DateTime RequestDate { get; set; }
        public bool? Access { get; set; }
        public DateTime? RequestProcessedDate { get; set; }
        public int ExternalSystemId { get; set; }
        public int StaffMemberId { get; set; }

        public virtual ExternalSystemDbo ExternalSystem { get; set; }
        public virtual StaffMemberDbo StaffMember { get; set; }
    }
}
