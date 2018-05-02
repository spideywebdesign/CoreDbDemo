using CoreDbDemo.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDbDemo.Repository.Interfaces
{
    public interface IRetailerRepository
    {
        Task<RetailerDbo> Get(int id);
        Task<IEnumerable<RetailerDbo>> GetAll();
        Task<RetailerDbo> GetByStaffMember(StaffMemberDbo staffMember);
        Task<RetailerDbo> GetByStaffMember(int id);
        Task<int> Save(RetailerDbo retailer);
    }
}