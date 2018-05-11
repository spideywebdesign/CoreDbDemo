using System.Collections.Generic;

namespace CoreDbDemo.Model.Entity
{
    public class AreaManagerDbo : EntityBase
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<RetailerDbo> Retailers { get; set; }
        //public virtual ICollection<BrandDbo> Brands { get; set; }
    }
}