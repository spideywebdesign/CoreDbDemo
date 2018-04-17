using System.Collections.Generic;

namespace CoreDbDemo.Model.Entity
{
    public class ExternalSystem : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
