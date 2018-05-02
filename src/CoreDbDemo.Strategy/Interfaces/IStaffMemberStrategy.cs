using CoreDbDemo.Model.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDbDemo.Strategy.Interfaces
{
    public interface IStaffMemberStrategy
    {
        Task<StaffMember> Get(int id);
        Task<IEnumerable<StaffMember>> GetAll();
        Task<IEnumerable<StaffMember>> GetByRetailer(Retailer retailer);
        Task<IEnumerable<StaffMember>> GetByRetailer(int id);
        Task<StaffMember> Save(StaffMember retailer);
    }
}
