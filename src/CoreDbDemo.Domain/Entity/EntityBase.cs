using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDbDemo.Model.Entity
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
