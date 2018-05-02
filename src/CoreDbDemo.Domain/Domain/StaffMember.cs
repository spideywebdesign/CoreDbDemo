namespace CoreDbDemo.Model.Domain
{
    public class StaffMember : DomainBase
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int RetailerId { get; set; }
        public Retailer Retailer { get; set; }
    }
}