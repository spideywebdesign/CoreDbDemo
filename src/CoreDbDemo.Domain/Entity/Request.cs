using System;

namespace CoreDbDemo.Model.Entity
{
    public class Request : EntityBase
    {
        public DateTime RequestDate { get; set; }
        public bool? Access { get; set; }
        public DateTime? RequestProcessedDate { get; set; }
        public int ExternalSystemId { get; set; }

        public virtual ExternalSystem ExternalSystem { get; set; }
        public virtual StaffMember StaffMember { get; set; }
    }
}
