using CoreDbDemo.Model.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDbDemo.Strategy.Interfaces
{
    public interface IRetailerStrategy
    {
        Task<Retailer> Get(int id);
        Task<IEnumerable<Retailer>> GetAll();
        Task<Retailer> GetByStaffMember(StaffMember staffMember);
        Task<Retailer> GetByStaffMember(int id);
        Task<Retailer> Save(Retailer retailer);
    }
}