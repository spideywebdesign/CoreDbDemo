using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreDbDemo.Model.Domain
{
    public class Retailer : DomainBase
    {
        [Required(ErrorMessage = "You must supply a Retailer Code.")]
        [StringLength(5, ErrorMessage = "Retailer code must be 5 characters long.", MinimumLength = 5)]
        public string RetailerCode { get; set; }
        [Required(ErrorMessage = "Address Line 1 is required.")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        [Required(ErrorMessage = "Town is required.")]
        public string Town { get; set; }
        [Required(ErrorMessage = "County is required.")]
        public string County { get; set; }
        [Required(ErrorMessage = "Postcode is required.")]
        public string Postcode { get; set; }

        public AreaManager AreaManager { get; set; }
        public Brand Brand { get; set; }
        public IEnumerable<StaffMember> StaffMembers { get; set; }
    }
}