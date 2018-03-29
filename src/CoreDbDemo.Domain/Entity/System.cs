using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDbDemo.Model.Entity
{
    public class System : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
