using System.Collections.Generic;

namespace CoreDbDemo.Model.Domain
{
    public class ExternalSystem : DomainBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Request> Requests { get; set; }
    }
}