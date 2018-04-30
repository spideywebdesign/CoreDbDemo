using System.Collections.Generic;

namespace CoreDbDemo.Model.Entity
{
    public class ExternalSystemDbo : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RequestDbo> Requests { get; set; }
    }
}
