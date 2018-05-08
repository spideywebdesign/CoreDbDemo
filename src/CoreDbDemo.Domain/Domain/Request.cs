using System;

namespace CoreDbDemo.Model.Domain
{
    public class Request : DomainBase
    {
        public DateTime RequestDate { get; set; }
        public bool? Access { get; set; }
        public DateTime? RequestProcessedDate { get; set; }
        public int ExternalSystemId { get; set; }
        public int StaffMemberId { get; set; }

        public virtual ExternalSystem ExternalSystem { get; set; }
        public virtual StaffMember StaffMember { get; set; }
    }
}