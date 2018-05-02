using CoreDbDemo.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDbDemo.Repository.Interfaces
{
    public interface IStaffMemberRepository
    {
        Task<StaffMemberDbo> Get(int id);
        Task<IEnumerable<StaffMemberDbo>> GetAll();
        Task<IEnumerable<StaffMemberDbo>> GetByRetailer(RetailerDbo retailer);
        Task<IEnumerable<StaffMemberDbo>> GetByRetailer(int id);
        Task<int> Save(StaffMemberDbo retailer);
    }
}